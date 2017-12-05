using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intex.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateOrder()
        {
            return View();
        }

        public ActionResult ViewOrder()
        {
            return View();
        }

        public ActionResult NotificationSettings()
        {
            return View();
        }

        public ActionResult PastOrders()
        {
            return View();
        }

        public ActionResult GetQuote()
        {
            return View();
        }

        public ActionResult ViewTestResults()
        {
            return View();
        }

        public ActionResult ChatWithRepresentative()
        {
            return View();
        }

    }
}