using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.ViewModels
{
    public class PostImgs
    {
        public Post post { get; set; }
        public IEnumerable<PostImage> PostImages { get; set; }

    }
}