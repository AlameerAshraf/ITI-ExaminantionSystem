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
        public ActionResult CreateExamExternal(int AccessSecret)
        {
            return Content("Done ,CreateExam");
        }

        [HttpGet]
        public ActionResult CraeteExam(int? Message_id)
        {
            TempData["Message_id"] = Message_id;
            TempData.Keep("Message_id");
            return Content(Message_id.ToString());
        }
    }
}