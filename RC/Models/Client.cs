using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
       
        public string Gender { get; set; }
        public string businessEmail { get; set; }
        public string Address { get; set; }
    
        public DateTime dateOfBirth { get; set; }

        public int Age { get; set; }
        public int Points { get; set; }


        //User Model 
        public User User { get; set; }
        public int userId { get; set; }


        //City Model 

        public City City { get; set; }
        public int cityId { get; set; }







    }
}