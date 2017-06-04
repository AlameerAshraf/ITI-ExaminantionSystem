using BusineesLayer.Managers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR.Client;

namespace App_iti.Controllers
{
    public class EmployeeController : Controller
    {

        HttpClient App;
        string Replacable_URL = "http://localhost:51822";
        string Urle;

        // Employee Login 
        public ActionResult AppUser()
        {
            return View();
        }

        public async Task<ActionResult> AppProfile(string UserName)
        {
            var cookie_token = Request.Cookies[UserName];
            var access_token = cookie_token.Value;
            var trav_access_token = ("Bearer"+" " + access_token).ToString();


            App = new HttpClient();
            Urle = Replacable_URL + "/api/Employee/EmployeeUserLogin?UserName=" + UserName;
            App.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            App.DefaultRequestHeaders.Add("Authorization", trav_access_token);
            HttpResponseMessage Response = await App.GetAsync(Urle);
            var responseData = Response.Content.ReadAsStringAsync().Result;
            var EmpData = JsonConvert.DeserializeObject<EmployeetAutherization>(responseData);

            return View(EmpData);
        }


        public ActionResult SignalREmp1()
        {
            return View();
        }

        public ActionResult SignalREmp2()
        {
            return View();
        }


    }
}