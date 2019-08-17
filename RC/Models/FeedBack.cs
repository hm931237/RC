using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string userType { get; set; }
        //Model User

        //public User User { get; set; }
        //public int userId { get; set; }
    }
}