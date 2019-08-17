using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class AdsClick
    {
        public int Id { get; set; }
        public Advertisement Advertisment { get; set; }
        public int advertismentId { get; set; }
        public User User { get; set; }
        public int userId { get; set; }
    }
}