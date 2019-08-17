using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RC.Models;

namespace RC.ViewModels
{
    public class reportdisplay
    {
        public IEnumerable<Report> orgReport { get; set; }

        public IEnumerable<Report> revReport { get; set; }

        public List<string> orgUsername { get; set; }

        public List<string> clientUsername { get; set; }
    }
}