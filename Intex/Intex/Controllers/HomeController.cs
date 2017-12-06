using Intex.DAL;
using Intex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Intex.Controllers
{
    public class HomeController : Controller
    {
        private IntexContext db = new IntexContext();
        public class Qty
        {
            int qty;
            int testID;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Username"].ToString();
            String password = form["Password"].ToString();

            if (string.Equals(email, "employee") && (string.Equals(password, "employee")))
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return RedirectToAction("Display", "Orders");

            }
            else if (string.Equals(email, "client") && (string.Equals(password,"client")))
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return RedirectToAction("Catalogue", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid username or password";
                return View();

            }
        }

        [HttpGet]
        public ActionResult Catalogue()
        {
            IEnumerable<Test> test =
                 db.Database.SqlQuery<Test>(
                "Select Test.testID, Test.testName, Test.equipmentReq, Test.procedures, " +
                "Test.basePrice, Test.testPrice FROM Test");

            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Catalogue([Bind(Include = "testID,qty")] Qty qty)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
/*
 *
@{
    ViewBag.Title = "Catalogue";
}

<h2>Catalogue</h2>

<table class="table">
    <thead>
        <tr>
            <th scope="col"><!--image--></th>
            <th scope="col">Service</th>
            <th scope="col">Description</th>
            <th scope="col">Price</th>
            <th scope="col"><!--button--></th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <th scope="row"><img src="~/Content/img/test tubes.png" style="opacity:0.9; width:50%; height:auto"/></th>
            <td>Kewl product</td>
            <td><p>This product will things you've always wanted to do. This product will help you to do all the hings you've always wanted to do. to do. This product will help you to do all the different things you've always wanted to do. </p></td>
            <td>$12.34</td>
            <td><a href="@Url.Action("Index", "Home")" class="btn btn-danger btn-lg"> Add to cart <i class='glyphicon glyphicon-plus-sign'></i></a></td>
        </tr>
        <tr>
            <th scope="row">2</th>
            <td>Jacob</td>
            <td>Thornton</td>
            <td>asdf</td>
        </tr>
        <tr>
            <th scope="row">3</th>
            <td>Larry</td>
            <td>the Bird</td>
            <td>3f33</td>
        </tr>
    </tbody>
</table>
*/