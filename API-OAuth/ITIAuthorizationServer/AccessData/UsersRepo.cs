using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.Models;
using BusineesLayer.Managers;
using BusineesLayer.Map;

namespace ITIAuthorizationServer.AccessData
{
    public class UsersRepo
    {
        List<Employee> EmpList ;
        List<StudentAutherization> StdAuth;
        StudentMananger StdManager = new StudentMananger();
        EmployeeManager EmpManager = new EmployeeManager();


        public List<Employee> GetEmps()
        {
            EmpList = new List<Employee>();
            EmpList = EmpManager.GetEmployees();
            return EmpList;
        }

        public List<StudentAutherization> GetStds()
        {
            StdAuth = new List<StudentAutherization>();
            StdAuth = StdManager.GetStudents();
            return StdAuth;
        }

    }
}


