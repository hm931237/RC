using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.ViewModels
{
    public class OrganizationIndexPost
    {
        public Organization organization { get; set; }

        public Stack<Post> posts { get; set; }
        public List<PostImage> postImages { get; set; }

        public IEnumerable<PostReaction> PostReaction { get; set; }

        public Promotion Promotion { get; set; }
        public PromotionAge PromotionAge { get; set; }

        public IEnumerable<Promotion> Promotions { get; set; }
        public User LoginUser { get; set; }

    }
}