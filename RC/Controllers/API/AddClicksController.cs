using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace RC.Controllers.API
{
    public class AddClicksController : ApiController
    {
        private ApplicationDbContext _context;
        public AddClicksController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Click(AdsClick AdsClick)
        {
            var click = _context.AdsClicks.SingleOrDefault(C=>C.advertismentId== AdsClick.advertismentId && C.userId == AdsClick.userId);
            if(click != null)
            {
                return Ok();
            }
            else
            {
                _context.AdsClicks.Add(AdsClick);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
