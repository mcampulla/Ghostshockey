using ghostshockey.it.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ghostshockey.it.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            CancellationTokenSource _cts0 = new CancellationTokenSource();
            AppController.AddYear("pippo",
                // Service call success                 
                (data) =>
                {
                    var s = data;
                },
                // Service call error
                (error) =>
                {
                    //if (error.Contains("confirm"))
                    //    this.VerifyButton.Visibility = ViewStates.Visible;

                    //Toast.MakeText(this.Activity.Application, error, ToastLength.Long).Show();
                },
                // Service call finished 
                (exception) =>
                {
                    //    _isLogginUser = false;

                    //// Allow user to tap views
                    //((MainActivity)this.Activity).UnblockUI();
                });

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}