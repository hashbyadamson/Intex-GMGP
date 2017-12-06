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
using System.IO;
using System.Data.SqlClient;

namespace Intex.Controllers
{
    public class OrdersController : Controller
    {
        private IntexContext db = new IntexContext();

        [Authorize]
        public ActionResult Display()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                
                string filePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
                file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), filePath));
                //Here you can write code for save this information in your database if you want


                TempData["Name"] = file.FileName.ToString();



            }
            string name = TempData["Name"].ToString();
           
            SqlConnection conn;
            conn = new SqlConnection("Data Source=SPENCERLAPTOP\\SQLEXPRESS;Initial Catalog=Blowout;Integrated Security=True;Pooling=False");
            try
            {
                // Open the connection
                conn.Open();

                // prepare command string
                string insertString = @"
            
            USE INTEX
            UPDATE R 
            SET R.rawData = '" +  name  + @"'
            FROM [Order] AS P
            INNER JOIN Data_Report AS R 
            ON R.dataReportID = P.dataReportID
            WHERE clientID = 2 and P.dataReportID = 10001";

                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(insertString, conn);

                // 2. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            };
            return View("Display");
        }


        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Client).Include(o => o.Data_Report).Include(o => o.Employee).Include(o => o.Order_Progress);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
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

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "clientID", "clientFirstName", order.ClientID);
            ViewBag.dataReportID = new SelectList(db.Data_Reports, "dataReportID", "rawData", order.dataReportID);
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeFirstName", order.employeeID);
            ViewBag.orderProgress = new SelectList(db.Order_Progresses, "orderProgress", "orderProgress", order.orderProgress);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderID,comment,resultsMailed,summaryReport,comfirmationSenddatetime,orderProgress,employeeID,dataReportID,ClientID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "clientID", "clientFirstName", order.ClientID);
            ViewBag.dataReportID = new SelectList(db.Data_Reports, "dataReportID", "rawData", order.dataReportID);
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeFirstName", order.employeeID);
            ViewBag.orderProgress = new SelectList(db.Order_Progresses, "orderProgress", "orderProgress", order.orderProgress);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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

        public ActionResult PastOrders()
        {
            IEnumerable<PastOrders> clientPastOrders =
                db.Database.SqlQuery<PastOrders>(
                    "Select [Order].orderID, [Order].clientID, [Order].orderProgress," +
                    "[Order].comment, [Order].summaryReport, [Order].resultsMailed " +
                    "FROM [Order] " +
                    "WHERE [Order].clientID = 4");

            return View(clientPastOrders);
        }
    }
}
