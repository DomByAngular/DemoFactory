using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ActionResultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentResult()
        {
            return Content("Hi, 我是ContentResult结果");
        }

        public ActionResult EmptyResult()
        {
            //空结果当然是空白了!
            //至于你信不信, 我反正信了
            return new EmptyResult();
        }

        public ActionResult FileResult()
        {
            var imgPath = Server.MapPath("~/demo.jpg");

            return File(imgPath, "application/x-jpg", "demo.jpg");
        }

        public ActionResult HttpNotFoundResult()
        {
            return HttpNotFound("Page Not Found");
        }

        public ActionResult HttpUnauthorizedResult()
        {
            //未验证时,跳转到Logon
            return new HttpUnauthorizedResult();
        }

        public ActionResult JavaScriptResult()
        {
            string js = "alert(\"Hi, I'm JavaScript.\");";

            return JavaScript(js);
        }

        public ActionResult JsonResult()
        {
            var jsonObj = new
            {
                Id = 1,
                Name = "小铭",
                Sex = "男",
                Like = "足球"
            };

            return Json(jsonObj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RedirectResult()
        {
            return Redirect("~/demo.jpg");
        }

        public ActionResult RedirectToRouteResult()
        {
            return RedirectToRoute(new { 
                controller = "Hello", action = "" 
            });
        }

        public ActionResult ViewResult()
        {
            return View();
        }

        public ActionResult PartialViewResult()
        {
            return PartialView();
        }

        //禁止直接访问的ChildAction
        [ChildActionOnly]
        public ActionResult ChildAction()
        {
            return PartialView();
        }

        //正确使用ChildAction
        public ActionResult UsingChildAction()
        {
            return View();
        }
    }
}