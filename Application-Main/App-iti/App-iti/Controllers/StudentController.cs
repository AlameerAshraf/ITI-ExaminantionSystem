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
            var trav_access_token = ("Bearer" + " " + access_token).ToString();


            App = new HttpClient();
            Urle = "http://localhost:51822/api/Student/StdUserLogin/?UName=" + UserName;
            //App.BaseAddress = new Uri(Url);
            //App.DefaultRequestHeaders.Accept.Clear();
            App.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            App.DefaultRequestHeaders.Add("Authorization",trav_access_token);
            HttpResponseMessage Response = await App.GetAsync(Urle);
            var responseData = Response.Content.ReadAsStringAsync().Result;
            var StdData = JsonConvert.DeserializeObject<StudentMap>(responseData); 
            

            return Content(access_token + "is logged in");
        }

        
    }
}