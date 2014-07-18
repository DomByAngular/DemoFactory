using System.Web.Mvc;

namespace MvcBlog_Example.Areas.BlogManager
{
    public class BlogManagerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BlogManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BlogManager_default",
                "BlogManager/{userName}",
                new { controller = "Home", action = "Index" }
            );
        }
    }
}
