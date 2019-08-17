using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RC.Models;

namespace RC.ViewModels
{
    public class OrganizationFilterVIewModel
    {
        public List<Organization> Organizations { get; set; }

        public List<Sector> Sectors { get; set; }
        public int sectorId { get; set; }

        public List<City> Cities { get; set; }
        public int cityId { get; set; }

        public List<Category> Categories { get; set; }
        public int categoryId { get; set; }

        public List<PriceRange> PriceRanges { get; set; }
        public int priceRangeId { get; set; }

        public int Rate { get; set; }

        public string query { get; set; }

        public int client_id { get; set; }

        public int userType { get; set; }

        public List<int> OrganizationIdList { get; set; }

    }
}