using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.ViewModels
{
    public class PostsForEveryUser
    {
        public IEnumerable<User> user { get; set; }

        public Client client { get; set; }

        public IEnumerable<Subscriber> Subscribers { get; set; }

        public IEnumerable<Organization> Organizations { get; set; }

        public IEnumerable<Post> Posts { get; set; }

        public IEnumerable<PostImage> PostImages { get; set; }

        public IEnumerable<PostReaction> Reactions { get; set; }

        public IEnumerable<Promotion> Promotion { get; set; }
        public IEnumerable<PromotionAge> PromotionAge { get; set; }

        public IEnumerable<Advertisement> Advertisement { get; set; }

        public int userID { get; set; }


    }
}