using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RC.Dtos;
using RC.Models;

namespace RC.Controllers.Api
{
    public class ReviewController : ApiController
    {
        private ApplicationDbContext _context;

        public ReviewController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Review(ReviewDto reviewDto)
        {
            var organizationfactors = _context.OrganizationFactors.Where(c => c.Organization.Id == reviewDto.organizationId).ToList();
            var reviewInDB = _context.Reviews.SingleOrDefault(c => c.clientId == reviewDto.clientId && c.organizationId == reviewDto.organizationId);
            float total_rate = 0;
            foreach (var rate in reviewDto.ratedFactors)
            {
                total_rate += rate;
            }
            if (reviewInDB == null)
            {
                Review review = new Review()
                {
                    generalFeedback = reviewDto.generalFeedback,
                    clientId = reviewDto.clientId,
                    organizationId = reviewDto.organizationId,
                    TotalRate = total_rate / (reviewDto.ratedFactors.Count * 10),
                    Date = DateTime.Now
                };
                _context.Reviews.Add(review);
                var client = _context.Clients.SingleOrDefault(c => c.Id == reviewDto.clientId);
                client.Points = client.Points + 20;
                _context.SaveChanges();
                var i = 0;
                foreach (var orgfactor in organizationfactors)
                {
                    ReviewFactors reviewFactors = new ReviewFactors()
                    {
                        Rate = reviewDto.ratedFactors[i],
                        organizationFactorId = orgfactor.Id,
                        reviewId = review.Id
                    };
                    i++;
                    _context.ReviewFactors.Add(reviewFactors);
                }
                _context.SaveChanges();
                updateRating(reviewDto.organizationId);
            }
            else
            {
                reviewInDB.generalFeedback = reviewDto.generalFeedback;
                reviewInDB.Date = DateTime.Now;
                reviewInDB.TotalRate = total_rate / (reviewDto.ratedFactors.Count * 10);
                var reviewFactorsInDB = _context.ReviewFactors.Where(c => c.reviewId == reviewInDB.Id).ToList();
                var i = 0;
                foreach (var reviewFactor in reviewFactorsInDB)
                {
                    var reviewFactorInDB = _context.ReviewFactors.SingleOrDefault(c => c.Id == reviewFactor.Id);
                    reviewFactorInDB.Rate = reviewDto.ratedFactors[i];
                    i++;
                }
                _context.SaveChanges();
                updateRating(reviewDto.organizationId);  

            }
            

            return Ok();
        }
        public void updateRating(int id)
        {

            List<average_rate> result = _context.ReviewFactors
                .Where(c => c.Review.organizationId == id)
                .GroupBy(c => c.organizationFactorId)
                .Select(m => new average_rate { factor = m.Key, count = m.Count(), sum = m.Sum(b => b.Rate) })
                .ToList();
            var organization = _context.Organizations.SingleOrDefault(c => c.Id == id);
            var organizationfactors = _context.OrganizationFactors.Where(c => c.Organization.Id == id).ToList();
            var i = 0;
            float rate = 0;
            foreach (var organizationFactor in organizationfactors)
            {
                organizationFactor.factorRate = result[i].sum / (result[i].count * 10);
                rate += result[i].sum / (result[i].count * 10);
                i++;
            }

            rate = rate / organizationfactors.Count * 10;
            organization.orgRate = rate;
            _context.SaveChanges();
        }
    }
}
