using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.ViewModels
{
    public class OrganizationPromotions
    {
        public Organization organization { get; set; }
        public IEnumerable<Post> posts { get; set; }
        public IEnumerable<Promotion> promotions { get; set; }
        public IEnumerable<PromotionViewer> PromotionViewer { get; set; }
        public User UserLoggedIn { get; set; }
        public IEnumerable<PostImage> PostImages { get; set; }
    }
}