using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Hi, 我是Index操作方法
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        /// <summary>
        /// 厄, 我是About操作方法
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }

        [ActionName("NewActionName")]
        public ActionResult RenameAction()
        {
            return Content("利用特性换个马甲");
        }

        /// <summary>
        /// 可以为方法添加不是操作方法的特性
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public string NonAction()
        {
            return "亲,不好意思噢.我不是操作方法噢,请不要乱调用噢!";
        }

        public ActionResult UsingParams(string p1, int? p2, string p3)
        {
            string output = string.Empty;
            output += "p1 = " + (p1 ?? "null");
            output += "<br />p2 = " 
                + (p2.HasValue ? p2.Value.ToString() : "没有值");
            output += "<br />p3 = " + (p3 ?? "null");
            return Content(output);
        }
    }
}
