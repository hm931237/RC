using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class Advertisement
    {
        public int Id { get; set; }

        [Required]
        public string Link { get; set; }

        //[Required]
        public string imageUrl { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [Required]
        public DateTime startDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [Required]
        public DateTime endDate { get; set; }


        //User Block
        //public User User { get; set; }
        //public int adminId { get; set; }

    }
}