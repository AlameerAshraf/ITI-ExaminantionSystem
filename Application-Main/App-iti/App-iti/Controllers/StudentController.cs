using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_iti.Controllers
{
    public class StudentController : Controller
    {
        //Login
        public ActionResult AppUser()
        {
            return View();
        }

        // Home - Profile 
        public ActionResult Home()
        {

            return RedirectToAction("Test");
        }

        public ActionResult Test(string UserName)
        {
            return Content(UserName + "is logged in");
        }

        // 
    }
}