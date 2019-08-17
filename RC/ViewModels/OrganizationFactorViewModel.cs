using RC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RC.ViewModels
{
    public class OrganizationFactorViewModel
    {
        public Organization Organization { get; set; }

        [Required]
        public string feedback { get; set; }

        public List<int> orgfactors { get; set; }

        public List<OrganizationFactor> OrganizationFactors { get; set; }


        public List<Client> clients { get; set; }

        public List<ReviewFactors> ReviewFactors { get; set; }

        public List<Review> Reviews { get; set; }


        public Report report { get; set; }
        public IEnumerable<ReportType> ReportTypes { get; set; }


        public List<KeyValuePair<int, int>> ClientReviewsNumber { get; set; }

        public int currentUserType { get; set; }

        public string revContent { get; set; }

        public string orgContent { get; set; }


   






    }
}