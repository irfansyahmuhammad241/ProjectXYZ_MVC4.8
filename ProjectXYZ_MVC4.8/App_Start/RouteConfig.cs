using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectXYZ_MVC4._8
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Company",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Company", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Manager",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Manager", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
