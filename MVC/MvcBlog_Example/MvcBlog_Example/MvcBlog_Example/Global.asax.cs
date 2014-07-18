using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;

namespace MvcBlog_Example
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

            string extension = ConfigurationManager.AppSettings["ExtensionName"] ?? string.Empty;

            extension = string.IsNullOrWhiteSpace(extension) ? string.Empty : "." + extension;

            string[] _namespace = new string[] { "MvcBlog_Example.Controllers" };

            routes.MapRoute("AllBlogs",
                "",
                new { controller = "Blog", action = "AllBlogs" },
                null,
                _namespace
            );
                

            //实现http://localhost:5680/User1 (不带/home.jsp)
            routes.MapRoute("BlogUser",
                "{userName}",
                new { controller = "Blog", action = "home" },
                new { userName = @"\w{5,}" },
                _namespace
            );

            //示范访问地址http://localhost:5680/User1/home.jsp
            routes.MapRoute("Blog",
                "{userName}/{action}" + extension,
                new { userName = "dotNetDR_", action = "home", controller = "Blog" },
                new { userName = @"\w{5,}" }, //用户名最少5个字母或数字或下划线
                _namespace
            );


            /* 你会发现当你输入/aa/home.jsp时~MVC会返回404错误页
             * 而输入/aa123/home.jsp时~MVC才会正确地跳转到404.jsp友显示页上!
             *
             * 实现404友好页
             */
            routes.MapRoute("NotFound",
                "404" + extension,
                new { controller = "Blog", action = "NotFound" },
                null, _namespace
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