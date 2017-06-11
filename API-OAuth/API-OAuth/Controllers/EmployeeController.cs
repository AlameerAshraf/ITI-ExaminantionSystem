using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Models;
using BusineesLayer.Managers;
using System.Web.Http;

namespace API_OAuth.Controllers
{
    public class EmployeeController : ApiController
    {

        EmployeeManager Emp = new EmployeeManager();
        NotificationManager Noti = new NotificationManager();

        [System.Web.Http.HttpGet]
        public EmployeetAutherization EmployeeUserLogin(string UserName)
        {
            return Emp.GetEmployeeData(UserName);
        }

        [System.Web.Http.HttpGet]
        public object IsExternalInstructor(int Id)
        {
            return Emp.IsExternal(Id);
        }

        [System.Web.Http.HttpPost]
        public bool InsertExternalToken(ExternalToken obj)
        {
            return Emp.CreateExternalSafeToken(obj);
        }

        [System.Web.Http.HttpGet]
        public List<NotificationRepo> OnLoadNotification(int Id , int Type)
        {
            return Noti.OnLoadNotification(Id, Type);
        }

    }
}