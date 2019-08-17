using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.ViewModels
{
    public class ReviewsDisplayViewModel
    {

        public Review  Review { get; set; }
        public Client client { get; set; }
        public IEnumerable<ReviewFactors> reviewFactors { get; set; }

    }
}