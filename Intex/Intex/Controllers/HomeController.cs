﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Catalogue()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

/*
 * /*
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