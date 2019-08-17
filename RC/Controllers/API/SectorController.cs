using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace RC.Controllers.Api
{
    public class SectorController : ApiController
    {
        private ApplicationDbContext _context;

        public SectorController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult AddSector(Sector sector)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
                 _context.Sector.Add(sector);
                 _context.SaveChanges();
            return Ok();
        }
    }
}
