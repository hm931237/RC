using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class PromotionViewer
    {
        public int Id { get; set; }

        //Model Promotion
        public Promotion Promotion { get; set; }
        public int promotionId { get; set; }

        //Model Client 
        public Client Client { get; set; }
        public int clientId { get; set; }

    }
}