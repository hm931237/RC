using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace RC.Models
{
    public class Phone
    {
      
        public int Id { get; set; }
        public string phoneNumber { get; set; }

        //User Model
        public User User { get; set; }
        public int userId { get; set; }

        
    }
}