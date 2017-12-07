using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intex.DAL;
using Intex.Models;
using System.Data.SqlClient;

namespace Intex.Controllers
{
    public class ClientsController : Controller
    {
        private IntexContext db = new IntexContext();

        public ActionResult Display()
        {
            return View();
        }
        
        public ActionResult QuoteForm()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QuoteForm(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                string comName = Request.Form["compoundName"];
                string samples = Request.Form["numSamples"];
                string email = Request.Form["inputEmail"];
                string fName = Request.Form["firstName"];
                string lName = Request.Form["lastName"];
                string comment = Request.Form["comments"];


                ViewBag.Compound = comName;
                ViewBag.Sample = samples;
                ViewBag.Email = email;
                ViewBag.FirstName = fName;
                ViewBag.LastName = lName;
                ViewBag.Comments = comment;
                return View("Summary");
            }

            return View();
        }
        
        public ActionResult Summary()
        {
            return View();
        }

        // GET: Clients
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.Login);
            return View(clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.username = new SelectList(db.Logins, "username", "password");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clientID,clientFirstName,clientLastName,addressLine1,addressLine2,clientCity,clientState,clientZip,clientPhone,clientCountry,clientDiscount,clientEmail,username")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.username = new SelectList(db.Logins, "username", "password", client.username);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.username = new SelectList(db.Logins, "username", "password", client.username);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clientID,clientFirstName,clientLastName,addressLine1,addressLine2,clientCity,clientState,clientZip,clientPhone,clientCountry,clientDiscount,clientEmail,username")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.username = new SelectList(db.Logins, "username", "password", client.username);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult PastOrder()
        {

            IEnumerable<PastOrders> pastOrder =
                 db.Database.SqlQuery<PastOrders>(
                "Select [Order].orderID, [Order].resultsMailed, [Order].clientID, " +
                "[Order].orderProgress, [Order].comment, " +
                "[Order].summaryReport " +
                "From [Order] WHERE [Order].clientID = 4");
            int clientID = 4;

            Client client = db.Clients.Find(clientID);
            ViewBag.client = client;


            return View(pastOrder);
        }


        // GET: Orders/Create
        public ActionResult CreateOrder()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "clientID", "clientFirstName");
            ViewBag.dataReportID = new SelectList(db.Data_Reports, "dataReportID", "rawData");
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeFirstName");
            ViewBag.orderProgress = new SelectList(db.Order_Progresses, "orderProgress", "orderProgress");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderID,comment,resultsMailed,summaryReport,comfirmationSenddatetime,orderProgress,employeeID,dataReportID,ClientID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "clientID", "clientFirstName", order.ClientID);
            ViewBag.dataReportID = new SelectList(db.Data_Reports, "dataReportID", "rawData", order.dataReportID);
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeFirstName", order.employeeID);
            ViewBag.orderProgress = new SelectList(db.Order_Progresses, "orderProgress", "orderProgress", order.orderProgress);
            return View(order);
        }


        public ActionResult ViewOrderStatus()
        {
            //these are only for testing this actionmethod
            string orderProgress = "Test in Progress";
            ViewBag.Orders = orderProgress;

            return View();
        }

        public ActionResult EditNotifications()
        {
            ViewBag.ReceiveEmail = true;
            return View();
        }
      






    }
}
