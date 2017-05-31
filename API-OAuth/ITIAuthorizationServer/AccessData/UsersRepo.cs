using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.Models;
using BusineesLayer.Managers;

namespace ITIAuthorizationServer.AccessData
{
    public class UsersRepo
    {
        List<Employee> EmpList ;
        List<StudentAutherization> StdAuth;
        StudentMananger StdManager = new StudentMananger();
        EmployeeManager EmpManager = new EmployeeManager();


        public List<Employee> GetEmps(int AutherizationLevel)
        {
            EmpList = new List<Employee>();
            if (AutherizationLevel == 1)
            {
                EmpList = EmpManager.GetEmployees();
            }
            else
            {
                EmpList = EmpManager.GetEmployees();
            }
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


