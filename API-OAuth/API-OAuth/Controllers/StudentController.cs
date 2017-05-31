using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusineesLayer.Managers;
using BusineesLayer.Map;
using System.Web.Http;
using DataAccessLayer.Models;

namespace API_OAuth.Controllers
{
   // [System.Web.Http.Authorize]
    public class StudentController : ApiController
    {

        StudentMananger std = new StudentMananger();


        [System.Web.Http.HttpGet]
        public List<StudentAutherization> onluone()
        {
            return std.GetStudents();
        }



        [System.Web.Http.HttpGet]
        public StudentMap StdUserLogin(string UName)
        {
            return std.GetStudentData(UName);
        }




    }

    
}