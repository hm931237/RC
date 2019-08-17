using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string generalFeedback { get; set; }
        public DateTime Date { get; set; }
        //Model Client

        public Client Client { get; set; }
        public int clientId { get; set; }

        //Model Organization 
        public Organization Organization { get; set; }
        public int organizationId { get; set; }

        public float TotalRate { get; set; }

        public int numberOfUseful { get; set; }

        public ICollection<ReviewFactors> ReviewFactorses { get; set; }
    }
}