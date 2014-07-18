using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication1.Controllers
{
    public class NoDefaultController : IController
    {
        void IController.Execute(RequestContext requestContext)
        {
            var httpContext = requestContext.HttpContext;

            var response = httpContext.Response;

            response.ContentType = "text/html; charset=utf-8";

            response.Write("自己的简单实现! Hello World");
        }
    }
}