using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RC.Models;

namespace RC.ViewModels
{
    public class OfferImage
    {
        public Offer offer { get; set; }
        public List<Offer> offers { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}