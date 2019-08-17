using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class Organization
    {
        public Organization()
        {
            state = 0;

        }
        public int Id { get; set; }
        public int state { get; set; }


        public string UsernameVerification { get; set; }
        [Required]
        public string ownerFirstName { get; set; }

        [Required]
        public DateTime EstablishOrg { get; set; }

        [Required]
        public string ownerLastName { get; set; }

        [Required]
        public string orgnizationName { get; set; }

        [Required]
        public string websiteUrl { get; set; }

        [Required]
        public string Fax { get; set; }

        [Required]

        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not valid.")]
        public string businessEmail { get; set; }

        //[Required]
        //public string priceRange { get; set; }

        [Required]
        public string socialLink_1 { get; set; }


        public string socialLink_2 { get; set; }


        //public DateTime JoinedAt { get; set; }

        [Required]
        public string Description { get; set; }

        public float orgRate { get; set; }


        //Model Category 

        public Category Category { get; set; }
        public int categoryId { get; set; }

        //Model User 

        public User User { get; set; }
        public int userId { get; set; }

        //Model City
        public City City { get; set; }
        public int cityId { get; set; }


        //Model Price Range 
        public PriceRange PriceRange { get; set; }
        public int PriceRangeId { get; set; }


        public ICollection<WorkTime> Worktimes { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<OrganizationFactor> OrganizationFactors { get; set; }
    }
}