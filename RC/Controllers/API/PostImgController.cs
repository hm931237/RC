using RC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RC.Controllers.Api
{
    public class PostImgController : ApiController
    {
       
        private ApplicationDbContext _context;

        public PostImgController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult DeleteImg(int imgId)
        {
            // Debug.WriteLine(postId);
            var Image = _context.PostImages.SingleOrDefault(c => c.Id == imgId);
            _context.PostImages.Remove(Image);
            _context.SaveChanges();
            return Ok();
        }
    }
}
