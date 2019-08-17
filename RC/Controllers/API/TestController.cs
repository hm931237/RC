using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RC.Controllers.API
{
    public class TestController : ApiController
    {
        private ApplicationDbContext _context;

        public TestController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult DeleteImg(int id)
        {
            // Debug.WriteLine(postId);
            var Image = _context.PostImages.SingleOrDefault(c => c.Id == id);
            _context.PostImages.Remove(Image);
            _context.SaveChanges();
            return Ok();
        }
    }
}
