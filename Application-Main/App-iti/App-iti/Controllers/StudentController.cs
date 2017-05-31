using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App_iti.Controllers
{
    public class StudentController : Controller
    {

        HttpClient App;
        string Url; 

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

        public async Task<ActionResult> Test(string UserName)
        {
            App = new HttpClient();
            Url = "http://localhost:51822/api/Student/?UName="+UserName;
            //App.BaseAddress = new Uri(Url);
            App.DefaultRequestHeaders.Accept.Clear();
            App.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage Response = await App.GetAsync(Url);
            var responseData = Response.Content.ReadAsStringAsync().Result;

            return Content(responseData + "is logged in");
        }

        // 
    }
}