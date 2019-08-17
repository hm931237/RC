using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class ReviewReaction
    {
        public int Id { get; set; }
        
        //Model Review 
        public Review Review { get; set; }
        public int reviewId { get; set; }

        //Model Client 
        public Client Client { get; set; }
        public int clientId { get; set; }
    }
}