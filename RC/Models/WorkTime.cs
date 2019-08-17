using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class WorkTime
    {
        public int Id { get; set; }

       // [DisplayFormat(DataFormatString = "{0:T}")]
        public DateTime From { get; set; }

       // [DisplayFormat(DataFormatString = "{0:T}")]
        public DateTime To { get; set; }

        public string Day { get; set; }

        //organization Model 

        public Organization organization { get; set; }
        public int OrganizationId { get; set; }


    }
}