using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class OrganizationFactor
    {
        public int Id { get; set; }

        public float factorRate { get; set; }
        //Factor Model 
        public Factor Factor { get; set; }
        public int factorId { get; set; }

        //Organization Model
        public Organization Organization { get; set; }
        public int organizationId { get; set; }
    }
}