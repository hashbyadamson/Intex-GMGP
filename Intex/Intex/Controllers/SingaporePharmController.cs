using Intex.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Net;
using Intex.Models;

namespace Intex.Controllers
{
    public class SingaporePharmController : Controller
    {
        public IntexContext db = new IntexContext();

        public ActionResult ViewPastTests()
        {
            var test_Results = db.Test_Results.Include(t => t.Data_Report).Include(t => t.Order).Include(t => t.Test);
            return View(test_Results.ToList());
        }

        public ActionResult PastTestDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Result test_Result = db.Test_Results.Find(id);
            if (test_Result == null)
            {
                return HttpNotFound();
            }
            return View(test_Result);
        }

        // GET: SingaporePharm
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


    }
}