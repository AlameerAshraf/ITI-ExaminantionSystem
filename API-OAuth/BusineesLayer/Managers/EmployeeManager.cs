using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using AutoMapper;

namespace BusineesLayer.Managers
{
    public class EmployeeManager : DataFactory<DataBaseCTX, Employee>
    {
        public List<Employee> GetEmployees()
        {
            var xx = new EmployeeManager().GetAll();
            var y = xx.ToList();
            return y;
        }

        public EmployeetAutherization GetEmployeeData(string UserName)
        {
            var emp = new EmployeeManager().FindBy(x => x.UserName2 == UserName);
            var empmap = Mapper.Map<EmployeetAutherization>(emp);

            var EmpType = empmap.TypeID; 
            if (EmpType == 0)
            {
                return empmap; 
            }
            else if (EmpType == 1)
            {

            }


            return empmap; 
        }




    }


    public class EmployeetAutherization
    {
        public int EmployeeID { get; set; }
        public string InstructorName { get; set; }
        public int BranchID { get; set; }
        public string IPassword { get; set; }
        public string UserName2 { get; set; }
        public int? PlatformID { get; set; }
        public int? TypeID { get; set; }
    }
}
