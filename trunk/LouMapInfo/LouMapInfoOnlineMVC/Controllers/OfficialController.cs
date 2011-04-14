using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LouMapInfoOnlineMVC.Controllers
{
    public class OfficialController : Controller
    {
        //
        // GET: /Official/

        public ActionResult Index()
        {
            if (Session["louSession"] == null)
                return View("Connect");
            return View("Players");
        }
        public ActionResult Connect()
        {
            return View();
        }

    }
}
