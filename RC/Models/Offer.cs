using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int requiredPoint { get; set; }
        public string rewardName { get; set; }
        public string imageUrl { get; set; }
        public string Description { get; set; }
        public string Qr_Gift { get; set; }


    }
}