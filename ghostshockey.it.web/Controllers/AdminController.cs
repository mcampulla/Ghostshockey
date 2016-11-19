using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ghostshockey.it.web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Years()
        {
            ViewBag.NgApp = "Years";
            return View();
        }

        public ActionResult Categories()
        {
            ViewBag.NgApp = "Categories";
            return View();
        }

        public ActionResult Clubs()
        {
            ViewBag.NgApp = "Clubs";
            return View();
        }

        public ActionResult Teams()
        {
            ViewBag.NgApp = "Teams";
            return View();
        }

        public ActionResult Matches()
        {
            ViewBag.NgApp = "Matches";
            return View();
        }

        public ActionResult Tournaments()
        {
            ViewBag.NgApp = "Tournaments";
            return View();
        }

        public ActionResult Players()
        {
            ViewBag.NgApp = "Players";
            return View();
        }
    }
}