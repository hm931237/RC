
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class UserLogin
    {


        public int Id { get; set; }

        
        public string Email { get; set; }
        [Required]
        public string username { get; set; }

        [Required]
        public string Password { get; set; }

        public string path { get; set; }

        public string imageUrl { get; set; }

        public UserType Role { get; set; }
        public byte roleId { get; set; }


    }
}