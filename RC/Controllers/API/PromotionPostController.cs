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
    public class PromotionPostController : ApiController
    {

        private ApplicationDbContext _context;
        public PromotionPostController()
        {
            _context = new ApplicationDbContext();
        }


        public IHttpActionResult Action(PromotionViewer PromotionViewer)
        {
            var promotionViewers = _context.PromotionViewers.SingleOrDefault(PV => PV.clientId == PromotionViewer.clientId && PV.promotionId == PromotionViewer.promotionId);
            var promotion = _context.Promotions.SingleOrDefault(p=>p.Id == PromotionViewer.promotionId);
                if (promotionViewers == null)
                {

                    var newViewer = new PromotionViewer();

                    newViewer.clientId = PromotionViewer.clientId;
                    newViewer.promotionId = PromotionViewer.promotionId;

                    _context.PromotionViewers.Add(newViewer);
                    _context.SaveChanges();

                promotion.Reaches = promotion.Reaches - 1;
                _context.SaveChanges();

                    return Ok();
                }
            

            
            return Ok();

        }





    }
}


