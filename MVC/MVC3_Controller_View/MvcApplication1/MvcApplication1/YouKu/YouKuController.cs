using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.YouKu
{
    public class YouKuController : Controller
    {
        public ActionResult Show(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        public ActionResult PlayList(string id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}