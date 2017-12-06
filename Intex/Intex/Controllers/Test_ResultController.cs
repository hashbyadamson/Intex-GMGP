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

namespace Intex.Controllers
{
    public class Test_ResultController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: Test_Result
        public ActionResult Index()
        {
            var test_Results = db.Test_Results.Include(t => t.Data_Report).Include(t => t.Order).Include(t => t.Test);
            return View(test_Results.ToList());
        }

        // GET: Test_Result/Details/5
        public ActionResult Details(int? id)
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

        // GET: Test_Result/Create
        public ActionResult Create()
        {
            ViewBag.dataReportID = new SelectList(db.Data_Reports, "dataReportID", "rawData");
            ViewBag.orderID = new SelectList(db.Orders, "orderID", "comment");
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName");
            return View();
        }

        // POST: Test_Result/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "testResultID,orderID,testID,dataReportID")] Test_Result test_Result)
        {
            if (ModelState.IsValid)
            {
                db.Test_Results.Add(test_Result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dataReportID = new SelectList(db.Data_Reports, "dataReportID", "rawData", test_Result.dataReportID);
            ViewBag.orderID = new SelectList(db.Orders, "orderID", "comment", test_Result.orderID);
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName", test_Result.testID);
            return View(test_Result);
        }

        // GET: Test_Result/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.dataReportID = new SelectList(db.Data_Reports, "dataReportID", "rawData", test_Result.dataReportID);
            ViewBag.orderID = new SelectList(db.Orders, "orderID", "comment", test_Result.orderID);
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName", test_Result.testID);
            return View(test_Result);
        }

        // POST: Test_Result/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "testResultID,orderID,testID,dataReportID")] Test_Result test_Result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test_Result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dataReportID = new SelectList(db.Data_Reports, "dataReportID", "rawData", test_Result.dataReportID);
            ViewBag.orderID = new SelectList(db.Orders, "orderID", "comment", test_Result.orderID);
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName", test_Result.testID);
            return View(test_Result);
        }

        // GET: Test_Result/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Test_Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test_Result test_Result = db.Test_Results.Find(id);
            db.Test_Results.Remove(test_Result);
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
    }
}
