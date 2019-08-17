using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class User
    {
        public User()
        {
            State = 1;
        }
        public int Id { get; set; }

       [Required]
        public string Username { get; set; }

        public DateTime JoniedAt { get; set; }

      [Required]     
        public string Password { get; set; }

        public int State { get; set; }

        [Required]
        public string imageUrl { get; set; }

      [Required]
      //[EmailAddress]
        public string Email { get; set; }


        public UserType UserType { get; set; }
        public byte UserTypeId { get; set; }

       // public virtual Phone phone { get; set; }



    }
}
