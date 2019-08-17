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
    public class newOrganizationsController : ApiController
    {
        private ApplicationDbContext _context;

        public newOrganizationsController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetOrganizations()
        {
            var Organizations = _context.Organizations.Where(m => m.state == 0);

            return Ok(Organizations);
        }

        //[System.Web.Http.HttpPut]
        //public IHttpActionResult DeleteOrganization(int Id)
        //{

        //    var organization = _context.Organizations.SingleOrDefault(c => c.Id == Id);

        //    organization.state = 2;

        //    _context.SaveChanges();
        //    return Ok();
           
        //}

        [System.Web.Http.HttpPut]
        public IHttpActionResult DeleteOrganization(int Id, [FromBody] string del)
        {

            var organization = _context.Organizations.SingleOrDefault(c => c.Id == Id);
            if (del == "Del")
            {
                organization.state = 2;
            }
            if (del == "Accept")
            {
                organization.state = 1;
            }
            
            _context.SaveChanges();
            return Ok();
        }

    }
}
