using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class averageRatings
    {
        public int id { get; set; }

        public DateTime DateOfUpdate { get; set; }

        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
    }
}