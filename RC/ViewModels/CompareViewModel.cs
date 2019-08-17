using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RC.Models;

namespace RC.ViewModels
{
    public class CompareViewModel
    {
        public List<Organization> organizations { get; set; }
        public List<int> Reviews { get; set; }

        public List<int> Reports { get; set; }

        public List<int> Followers { get; set; }

        public List<float> orgRates { get; set; }

    }
}