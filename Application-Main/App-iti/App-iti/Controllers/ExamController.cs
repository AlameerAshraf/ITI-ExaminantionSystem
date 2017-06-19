using Microsoft.AspNet.SignalR.Client;
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
            if (Message_id != null)
            {
                TempData["Message_id"] = Message_id;
                TempData.Keep("Message_id");

                IHubProxy _hub;
                string UrlSr = "http://localhost:51822";
                var connection = new HubConnection(UrlSr);
                _hub = connection.CreateHubProxy("examHub");
                connection.Start().Wait();

                _hub.Invoke("MarkNotification", Message_id);
            }


            return Content(Message_id.ToString());

        }
    }
}