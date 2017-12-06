using Intex.DAL;
using Intex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intex.Controllers
{
    public class SalesRepController : Controller
    {
        private IntexContext db = new IntexContext();

        // GET: SalesRep
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult CreateClient()
        {
            //ViewBag.username = new SelectList(db.Logins, "username", "password");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clientID,clientFirstName,clientLastName,addressLine1,addressLine2,clientCity,clientState,clientZip,clientPhone,clientCountry,clientDiscount,clientEmail")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.username = new SelectList(db.Logins, "username", "password", client.username);
            return View(client);
        }

        public ActionResult UpdateClient()
        {
            return View();
        }

        public ActionResult CreateQuote()
        {
            return View();
        }

        public ActionResult ViewOrders()
        {
            return View();
        }

        public ActionResult CreateOrder()
        {
            return View();
        }

        public ActionResult EditOrder()
        {
            return View();
        }

        public ActionResult ChatWithClient()
        {
            return View();
        }
    }
}