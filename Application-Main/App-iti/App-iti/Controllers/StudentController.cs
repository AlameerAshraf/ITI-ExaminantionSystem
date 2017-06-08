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
            TempData.Keep();

            App = new HttpClient();
            Urle = Replacable_URL+"/api/Student/StdUserLogin/?UName=" + UserName;
            //App.BaseAddress = new Uri(Url);
            //App.DefaultRequestHeaders.Accept.Clear();
            App.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            App.DefaultRequestHeaders.Add("Authorization",trav_access_token);
            HttpResponseMessage Response = await App.GetAsync(Urle);
            var responseData = Response.Content.ReadAsStringAsync().Result;
            var StdData = JsonConvert.DeserializeObject<StudentMap>(responseData);


            return View(StdData);
        }

        public async Task<ActionResult> SendExamNotification(int Id)
        {
            string trav_access_token = TempData["access_token"].ToString();
            App = new HttpClient();
            Urle = Replacable_URL + "/api/Employee/IsExternalInstructor/" + Id;
            App.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            App.DefaultRequestHeaders.Add("Authorization", trav_access_token);
            HttpResponseMessage Response =await App.GetAsync(Urle);
            var responseData = Response.Content.ReadAsStringAsync().Result;
            var ExcpectedObj = new { Email = "" };
            var EmpEmailState = JsonConvert.DeserializeAnonymousType(responseData, ExcpectedObj);

            return Content(EmpEmailState.ToString());

        }

        
    }
}