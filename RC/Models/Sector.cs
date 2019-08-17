using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class Sector
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Sector Name")]
        public string Name { get; set; }
        public string IconPath { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}