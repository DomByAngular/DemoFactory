using System.Web.Mvc;

namespace MvcApplication1
{
    public class HelloController : Controller
    {
        public ActionResult Index()
        {
            return Content("默认的实现! Hello World");
        }
    }
}