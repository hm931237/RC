using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "loading", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Filter",
                url: "Home/Filtering/query/{query}/sector/{sector}/category/{category}/city/{city}/priceRange/{priceRange}/rate/{rate}",
                defaults: new { controller = "Home", action = "Filtering", query = UrlParameter.Optional, sector = UrlParameter.Optional, category = UrlParameter.Optional, city = UrlParameter.Optional, priceRange = UrlParameter.Optional, rate = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Session",
                url: "Home/route/{userType}",
                defaults: new { controller = "Home", action = "route", userType = UrlParameter.Optional }
            );
        }
    }
}
