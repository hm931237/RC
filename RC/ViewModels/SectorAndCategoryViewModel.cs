using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.ViewModels
{
    public class SectorAndCategoryViewModel
    {
        public Category Category { get; set; }
        public Sector Sector { get; set; }
        public Factor Factor { get; set; }
        public IEnumerable<Sector> Sectors { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}