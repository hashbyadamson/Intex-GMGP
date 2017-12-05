using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intex.Controllers
{
    public class SeattlePharmController : Controller
    {
        // GET: SeattlePharm
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewOrders()
        {
            return View();
        }

        public ActionResult UpdateProgress()
        {
            return View();
        }

        public ActionResult UpdateOrder()
        {
            return View();
        }

        public ActionResult ViewInventory()
        {
            return View();
        }

        public ActionResult PostTestResults()
        {
            return View();
        }

        public ActionResult ViewPastTests()
        {
            return View();
        }
    }
}