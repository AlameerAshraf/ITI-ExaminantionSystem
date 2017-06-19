using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Models;
using BusineesLayer.Map;
using BusineesLayer.Managers;

namespace App_iti.Controllers
{
    public class StudentController : Controller
    {

        HttpClient App;
        string Replacable_URL = "http://localhost:51822"; 
        string Urle; 

        //Login
        public ActionResult AppUser()
        {
            return View();
        }

        // Profile 
        public async Task<ActionResult> AppProfile(string UserName)
        {
            var cookie_token = Request.Cookies[UserName];
            var access_token = cookie_token.Value;
            var trav_access_token = ("Bearer"+" "+access_token).ToString();
            TempData["access_token"] = trav_access_token;
            TempData.Keep("access_token");

            App = new HttpClient();
            Urle = Replacable_URL+"/api/Student/StdUserLogin/?UName=" + UserName;
            App.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            App.DefaultRequestHeaders.Add("Authorization",trav_access_token);
            HttpResponseMessage Response = await App.GetAsync(Urle);
            var responseData = Response.Content.ReadAsStringAsync().Result;
            var StdData = JsonConvert.DeserializeObject<StudentMap>(responseData);
            TempData["StdData"] = StdData;
            TempData.Keep("StdData");

            TempData["TypeContext"] = 5;
            TempData.Keep("TypeContext");

            return View(StdData);
        }


        public async Task<ActionResult> ExamScheduals()
        {
            string trav_access_token = TempData["access_token"].ToString();
            TempData.Keep("access_token");
            var Std = TempData["StdData"] as StudentMap;
            TempData.Keep("StdData");
            TempData.Keep("TypeContext");


            App = new HttpClient();
            Urle = Replacable_URL + "/api/Exam/GetSchedulesExams?PlatformId=" + Std.PlatformIntakeID ;
            App.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            App.DefaultRequestHeaders.Add("Authorization", trav_access_token);
            HttpResponseMessage Response = await App.GetAsync(Urle);
            var responseData = Response.Content.ReadAsStringAsync().Result;
            var ExamData = JsonConvert.DeserializeObject<List<ExamMetaData>>(responseData);


            return View(ExamData);
        }



        public async Task<ActionResult> StartExam(int id)
        {
            string trav_access_token = TempData["access_token"].ToString();
            TempData.Keep("access_token");
            var Std = TempData["StdData"] as StudentMap;
            TempData.Keep("StdData");
            TempData.Keep("TypeContext");


            App = new HttpClient();
            Urle = Replacable_URL + "/api/Exam/GetExamData?Ex_Id=" + id;
            App.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            App.DefaultRequestHeaders.Add("Authorization", trav_access_token);
            HttpResponseMessage Response = await App.GetAsync(Urle);
            var responseData = Response.Content.ReadAsStringAsync().Result;
            var ExamData = JsonConvert.DeserializeObject<ExamMetaData>(responseData);


            ViewBag.Std_Id = Std.StudentID;
            ViewBag.Track = Std.TrackId;
            ViewBag.Branch = Std.BranchID;
            ViewBag.ExId = id;
            return View(ExamData);
        }


        public ActionResult Exam()
        {
            string trav_access_token = TempData["access_token"].ToString();
            TempData.Keep("access_token");
            var Std = TempData["StdData"] as StudentMap;
            TempData.Keep("StdData");
            TempData.Keep("TypeContext");

            return View();
        }











    }
}