using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class PostReaction
    {
        public int Id { get; set; }

        public int Reaction { get; set; }

        //Model Post 
        public Post Post { get; set; }
        public int postId { get; set; }


        //Model Client 
        public ICollection<Client> Client { get; set; }
        public int clientId { get; set; }
    }
}