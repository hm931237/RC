using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class PostImage
    {
        public int Id { get; set; }

        public string Path { get; set; }


        //Model Post 
        public Post Post { get; set; }
        public int postId { get; set; }
    }
}