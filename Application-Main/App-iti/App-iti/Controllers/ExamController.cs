using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_iti.Controllers
{
    public class ExamController : Controller
    {
        // GET: Exam
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateExam(int Id)
        {
            return Content("Done ,CreateExam");
        }
    }
}