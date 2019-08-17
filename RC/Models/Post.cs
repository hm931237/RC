using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        //Model Organization 
        public Organization Organization { get; set; }
        public int organizationId { get; set; }
    }
}