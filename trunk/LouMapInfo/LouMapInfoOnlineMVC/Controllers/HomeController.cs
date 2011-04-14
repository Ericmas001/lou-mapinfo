using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LouMapInfoOnlineMVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Header"] = "Welcome to LoU Map Info Online";

            return View();
        }

        public ActionResult About()
        {
            ViewData["Header"] = "About";
            return View();
        }
    }
}
