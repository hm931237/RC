using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class Subscriber
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }

        //Model Client
        public Client Client { get; set; }
        public int clientId { get; set; }

        //Model Organization 
        public Organization Organization { get; set; }
        public int organizationId { get; set; }
    }
}