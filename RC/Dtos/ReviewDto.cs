using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Dtos
{
    public class ReviewDto
    {
        public string generalFeedback { get; set; }

        public int clientId { get; set; }

        public int organizationId { get; set; }

        public List<int> ratedFactors { get; set; }

    }
}