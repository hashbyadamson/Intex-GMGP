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

        public ActionResult Catalogue()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}