using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_iti.Controllers
{
    public class EmployeeController : Controller
    {
        // Employee Login 
        public ActionResult AppUser()
        {
            return View();
        }

        // Employee Home 
        public ActionResult Home()
        {
            var value = (string) null;
            var cookie = Request.Cookies["access_token"];
            if (cookie != null)
            {
                value = cookie.Value;
            }
            return Content("Access Token:" +value.ToString());
        }
    }
}