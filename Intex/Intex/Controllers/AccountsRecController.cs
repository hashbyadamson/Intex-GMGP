using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intex.Controllers
{
    public class AccountsRecController : Controller
    {

        public ActionResult ViewOrders()
        {
            return View();
        }

        public ActionResult UpdateOrders()
        {
            return View();
        }

        public ActionResult CreateInvoice()
        {
            //***
            return View();
        }

        public ActionResult EditInvoice()
        {
            //***
            return View();
        }

        public ActionResult ViewInvoice()
        {
            //***
            return View();
        }

        public ActionResult GenerateSalesReport()
        {
            //***
            return View();
        }
    }
}