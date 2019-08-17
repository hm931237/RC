using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RC.Controllers.API
{
    public class OrganizationController : ApiController
    {
        private ApplicationDbContext _context;

        public OrganizationController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IHttpActionResult GetOrganizations(string query = null)
        {
            var organizationsQuery = _context.Organizations.ToList();

            if (!String.IsNullOrWhiteSpace(query))
                organizationsQuery = organizationsQuery.Where(c=>c.orgnizationName.Contains(query)).ToList();

            
            return Ok(organizationsQuery);
        }
    }
}
