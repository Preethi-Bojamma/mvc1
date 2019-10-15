using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvc1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");//trace file

            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //    "SearchByIdAndName",
            //    "SearchByEmpIdName/{EmpId}/{Name}",
            //    new { controller = "Home",action="Edit"}
            //    );
               

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
