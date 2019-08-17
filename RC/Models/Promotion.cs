using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        [Display(Name = "Number Of Reaches")]
        [Range(1, 1000)]
        public int Reaches { get; set; }
        public int Profit { get; set; }
        [Display(Name = "Gender")]
        public int Gender { get; set; }

        //Model Post 
        public Post Post { get; set; }
        public int postId { get; set; }

        public bool isDone { get; set; }


    }
}