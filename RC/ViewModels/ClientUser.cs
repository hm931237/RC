
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RC.Models;

namespace RC.ViewModels
{
    public class ClientUser
    {
        public Client client { get; set; }
        public User user { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "you have to enter your confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public IEnumerable<City> city { get; set; }
    }
}