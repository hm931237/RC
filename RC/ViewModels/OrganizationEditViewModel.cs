using RC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RC.ViewModels
{
    public class OrganizationEditViewModel
    {

        public Organization Organization { get; set; }
        public Sector Sector { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Factor> Factors { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<PriceRange> PriceRanges { get; set; }
        public string phone { get; set; }

        public IEnumerable<OrganizationFactor> orgFactors { get; set; }


        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}