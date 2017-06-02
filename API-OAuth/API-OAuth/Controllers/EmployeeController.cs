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

        [System.Web.Http.HttpGet]
        public EmployeetAutherization GetIntake()
        {
            return Emp.GetEmployeeData("emp1035");
        }


    }
}