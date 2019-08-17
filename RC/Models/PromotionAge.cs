using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class PromotionAge
    {
        public int Id { get; set; }

        [Display(Name = "Start Age")]
        public int? startAge { get; set; }

        [Display(Name = "End Age")]
        public int? endAge { get; set; }

        //Model Promotion
        public Promotion Promotion { get; set; }
        public int promotionId { get; set; }


    }
}