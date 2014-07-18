using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ParamsController : Controller
    {
        string inputBlank = "你输入了空白";

        public ActionResult Index()
        {
            return View();
        }

        //默认是处理Get请求,当然你也可以显式添加
        [HttpGet]
        public ActionResult UsingViewBag()
        {
            return View();
        }

        //显式将操作方法设置处理Post请求
        [HttpPost]
        public ActionResult UsingViewBag(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                ViewBag.Msg = inputBlank;
            }
            else
            {
                ViewBag.Msg = "你输入了: " + input;
            }

            return View();
        }

        public ActionResult UsingViewData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UsingViewData(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                ViewData["msg"] = inputBlank;
            }
            else
            {
                ViewData["msg"] = "你输入了: " + input;
            }

            return View();
        }

        public ActionResult UsingTempData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UsingTempData(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                TempData["msg"] = inputBlank;
            }
            else
            {
                TempData["msg"] = "你输入了: " + input;
            }

            return View();
        }
    }
}
