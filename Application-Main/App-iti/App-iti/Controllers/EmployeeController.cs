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
using System.Net.Mail;

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
            var trav_access_token = ("Bearer"+" "+access_token).ToString();
            TempData["access_token"] = trav_access_token;
            TempData.Keep();

            App = new HttpClient();
            Urle = Replacable_URL + "/api/Employee/EmployeeUserLogin?UserName=" + UserName;
            App.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            App.DefaultRequestHeaders.Add("Authorization", trav_access_token);
            HttpResponseMessage Response = await App.GetAsync(Urle);
            var responseData = Response.Content.ReadAsStringAsync().Result;
            var EmpData = JsonConvert.DeserializeObject<EmployeetAutherization>(responseData);

            return View(EmpData);
        }

        public async Task<ActionResult> SendExamNotification(int Id)
        {
            string trav_access_token = TempData["access_token"].ToString();

            App = new HttpClient();
            Urle = Replacable_URL + "/api/Employee/IsExternalInstructor/" + Id;
            App.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            App.DefaultRequestHeaders.Add("Authorization", trav_access_token);
            HttpResponseMessage Response = await App.GetAsync(Urle);
            var responseData = Response.Content.ReadAsStringAsync().Result;
            var ExcpectedObj = new { Email = "" };
            var EmpEmailState = JsonConvert.DeserializeAnonymousType(responseData, ExcpectedObj);

            if (EmpEmailState.Email != "0")
            {
                SendMailSMTP(EmpEmailState.Email, "20/20/1994");
            }
            else
                return Content("Done");
            return Content(EmpEmailState.ToString());

        }



        public void SendMailSMTP(string External_Mail , string Exam_Date)
        {
            string SendTo = External_Mail;
            string Subject = "Enter Exam | ITI MS";
            string Message = "Hi Instructor , Your course exam have been scheduled at " + Exam_Date + " So Please add your Exam !";

            MailMessage Mess = new MailMessage();
            Mess.From = new MailAddress("alameerelnagar94@gmail.com");
            Mess.To.Add(External_Mail);
            Mess.Subject = Subject;
            Mess.Body = Message;
            Mess.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            System.Net.NetworkCredential NetworkCardential = new System.Net.NetworkCredential();
            NetworkCardential.UserName = "alameerelnagar94@gmail.com";
            NetworkCardential.Password = "01060931989";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCardential;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(Mess);
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