using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RC.Controllers.API
{
    public class FactorController : ApiController
    {
        private ApplicationDbContext _context;

        public FactorController()
        {
            _context = new ApplicationDbContext();

        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult AddSector(Factor factor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            _context.Factors.Add(factor);
            _context.SaveChanges();
            return Ok();
        }
    }
}
