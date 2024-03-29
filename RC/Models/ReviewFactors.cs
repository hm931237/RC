﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class ReviewFactors
    {
        public int Id { get; set; }
        public float Rate { get; set; }

        //Model Review
        public Review Review { get; set; }
        public int reviewId { get; set; }

        //Model OrganizationFactor
        public OrganizationFactor OrganizationFactor { get; set; }
        public int organizationFactorId { get; set; }

    }
}