using RC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RC.ViewModels
{
    public class OrganizationViewModel
    {

        [Required]
        public Organization Organization { get; set; }

        [Required]
        public User user { get; set; }

        [Required]
        public IEnumerable<Sector> Sectors { get; set; }

        [Required]
        public IEnumerable<Category> Categories { get; set; }

        [Required]
        public IEnumerable<Factor> Factors { get; set; }

        [Required]
        public IEnumerable<City> Cities { get; set; }

        [Required]
        public IEnumerable<PriceRange> PriceRanges { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }




        //[DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not valid.")]
        //public string personalEmail { get; set; }

          [Required]
        public Phone Phone { get; set; }

    }
}