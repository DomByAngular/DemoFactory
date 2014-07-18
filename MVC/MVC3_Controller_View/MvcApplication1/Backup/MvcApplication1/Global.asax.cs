using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //放在最前
            routes.MapRoute(
                "YouKu_Show",
                "v_{action}/id_{id}.html",
                new { controller = "YouKu" },
                new { id = "[a-z0-9]{13}" },
                new string[] { "MvcApplication1.YouKu" }
            );

            routes.MapRoute(
                "YouKu_PlayList",
                "v_{action}/{id}.html",
                new { controller = "YouKu" },
                new { id = "[a-z0-9]{12}" },
                new string[] { "MvcApplication1.YouKu" }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "UsingParams",
                "p/{p1}/{p2}/{p3}",
                new { 
                    controller = "Home", 
                    action = "UsingParams"
                },
                new { p1 = "[a-z0-9]+", p2 = @"\d+" }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}