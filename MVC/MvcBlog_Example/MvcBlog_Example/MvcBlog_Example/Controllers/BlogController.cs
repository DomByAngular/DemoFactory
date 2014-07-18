using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog_Example.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Home(string userName)
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

        public ActionResult Post(string userName)
        {
            ViewBag.UserName = userName;

            return View();
        }

        public ActionResult AllBlogs()
        {
            return View(Db.AllBlogUesr);
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
