﻿using BusineesLayer.Managers;
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
using System.Web.Script.Serialization;
using System.Text;

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
            var trav_access_token = ("Bearer" + " " + access_token).ToString();
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
                int Secret_Token = SecretToken();
                var Host = System.Web.HttpContext.Current.Request.UrlReferrer?.Authority;
                var RedierctedLink = "http://" + Host + "/Exam/CreateExam/?AccessSecret=" + Secret_Token;

                var ExternalToken = new ExternalToken()
                {
                    Code = Secret_Token,
                    Ins_Id = Id,
                    Expire_Date = DateTime.Now.AddDays(2)
                };
                var App_2 = new HttpClient();
                var Url = Replacable_URL + "/api/Employee/InsertExternalToken";
                App_2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                App_2.DefaultRequestHeaders.Add("Authorization", trav_access_token);
                var response = App.PostAsync(Url, new StringContent(
                    new JavaScriptSerializer().Serialize(ExternalToken), Encoding.UTF8, "application/json")).Result;

                SendMailSMTP(EmpEmailState.Email, "20/20/1994", RedierctedLink);
            }
            else
            {
                IHubProxy _hub;
                string Url = "http://localhost:51822/signalr";
                var connection = new HubConnection(Url);
                _hub = connection.CreateHubProxy("examHub");
                 connection.Start().Wait();
                _hub.Invoke("sendToPerson",1,"Message from c# Client").Wait();
            }
            return Content(EmpEmailState.ToString());

        }



        public void SendMailSMTP(string External_Mail, string Exam_Date, string Link)
        {
            string SendTo = External_Mail;
            string Subject = "Enter Exam | ITI MS";
            string Message = "Hi Instructor , Your course exam have been scheduled at " + Exam_Date + " So Please add your Exam !"
                             + "<br/>"
                             +"<a href =\"" + Link + "\">Click Here To Add Your Exam</a>" 

                             + "<br/>"
                             + "<p style='color:red'>note that your link be expired in <b>two days</b></p>";

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


        // Random !
        public int SecretToken()
        {
            Random R = new Random();
            int Token = R.Next(1, 99999);
            return Token;
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