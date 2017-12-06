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
    public class AccountsRecController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: AccountsRec
        public ActionResult ViewInvoice()
        {
            var invoices = db.Invoices.Include(i => i.Credit_Card_Payment).Include(i => i.Order).Include(i => i.Payment_Type);
            return View(invoices.ToList());
        }

        // GET: AccountsRec/Details/5
        public ActionResult InvoiceDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: AccountsRec/Create
        public ActionResult CreateInvoice()
        {
            ViewBag.creditCardPaymentNum = new SelectList(db.Credit_Card_Payments, "creditCardPaymentNum", "creditCardPaymentNum");
            ViewBag.orderID = new SelectList(db.Orders, "orderID", "comment");
            ViewBag.paymentTypeCode = new SelectList(db.Payment_Types, "paymentTypeCode", "paymentDescription");
            return View();
        }

        // POST: AccountsRec/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInvoice([Bind(Include = "invoiceID,paymentDue,paymentEarly,earlyPaymentDisc,orderID,paymentTypeCode,creditCardPaymentNum")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("ViewInvoice");
            }

            ViewBag.creditCardPaymentNum = new SelectList(db.Credit_Card_Payments, "creditCardPaymentNum", "creditCardPaymentNum", invoice.creditCardPaymentNum);
            ViewBag.orderID = new SelectList(db.Orders, "orderID", "comment", invoice.orderID);
            ViewBag.paymentTypeCode = new SelectList(db.Payment_Types, "paymentTypeCode", "paymentDescription", invoice.paymentTypeCode);
            return View(invoice);
        }

        // GET: AccountsRec/Edit/5
        public ActionResult EditInvoice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.creditCardPaymentNum = new SelectList(db.Credit_Card_Payments, "creditCardPaymentNum", "creditCardPaymentNum", invoice.creditCardPaymentNum);
            ViewBag.orderID = new SelectList(db.Orders, "orderID", "comment", invoice.orderID);
            ViewBag.paymentTypeCode = new SelectList(db.Payment_Types, "paymentTypeCode", "paymentDescription", invoice.paymentTypeCode);
            return View(invoice);
        }

        // POST: AccountsRec/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInvoice([Bind(Include = "invoiceID,paymentDue,paymentEarly,earlyPaymentDisc,orderID,paymentTypeCode,creditCardPaymentNum")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewInvoice");
            }
            ViewBag.creditCardPaymentNum = new SelectList(db.Credit_Card_Payments, "creditCardPaymentNum", "creditCardPaymentNum", invoice.creditCardPaymentNum);
            ViewBag.orderID = new SelectList(db.Orders, "orderID", "comment", invoice.orderID);
            ViewBag.paymentTypeCode = new SelectList(db.Payment_Types, "paymentTypeCode", "paymentDescription", invoice.paymentTypeCode);
            return View(invoice);
        }

        // GET: AccountsRec/Delete/5
        public ActionResult DeleteInvoice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: AccountsRec/Delete/5
        [HttpPost, ActionName("DeleteInvoice")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
            db.SaveChanges();
            return RedirectToAction("ViewInvoice");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult QuerySales()
        {
            //choose which query to see
            //add date?
            return View();
        }

        public ActionResult ViewSales()
        {
                ViewBag.decision = 1;
                IEnumerable<Sales_Report_By_Customer> sales_Report_ByCustomer =
                db.Database.SqlQuery<Sales_Report_By_Customer>(
                    "use intex " +
                    "select clientFirstName, clientLastName, basePrice, testPrice " +
                    "from client " +
                    "left join [order] on client.clientid = [order].clientID " +
                    "left join test_result on Test_Result.orderID = [order].orderID " +
                    "left join test on test.testid = Test_Result.testID " +
                    "where basePrice is not null"
                    );
                return View(sales_Report_ByCustomer);
            
        }
    }
}
