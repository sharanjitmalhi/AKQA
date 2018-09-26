using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NumericToWord
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "NumericToWord",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "NumericToWord", action = "NumericToWord", id = UrlParameter.Optional }
            );
        }
    }
}
