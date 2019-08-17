using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public Sector Sector { get; set; }

        [Required]
        [Display(Name = "Sector")]
        public int sectorId { get; set; }

        public ICollection<Factor> Factors { get; set; }
    }
}