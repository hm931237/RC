using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RC.Controllers.Api
{
    public class CategoryController : ApiController
    {
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
           
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult AddSector(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
                _context.Categories.Add(category);
                _context.SaveChanges();
            return Ok();
        }
    }
}
