using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intex.Controllers
{
    public class ManagementController : Controller
    {
        // GET: Management
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewOrders()
        {
            return View();
        }

        public ActionResult ViewClients()
        {
            return View();
        }

        public ActionResult ViewClientOrders()
        {
            return View();
        }

        public ActionResult ViewTests()
        {
            return View();
        }


        public ActionResult ViewReports()
        {
            return View();
        }
    }
}