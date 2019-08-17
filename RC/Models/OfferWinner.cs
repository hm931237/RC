using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class OfferWinner
    {
        public int Id { get; set; }


        //Client Model
        public Client Client { get; set; }
        public int clientId { get; set; }


        //Model Offer
        public Offer Offer { get; set; }
        public int offerId { get; set; }
    }
}