using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog_Example.Areas.BlogManager.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /BlogManager/Home/

        public ActionResult Index(string userName)
        {
            var _userName = Db.AllBlogUesr
                .Where(u => u.ToLower() == userName.ToLower())
                .FirstOrDefault();

            if (string.IsNullOrEmpty(_userName))
            {
                return RedirectToRoute("NotFound", new { userName = userName });
            }

            ViewBag.UserName = _userName;

            return View();
        }

    }
}
