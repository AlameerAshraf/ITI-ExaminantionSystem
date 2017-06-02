using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using AutoMapper;
using System.Data.SqlClient;

namespace BusineesLayer.Managers
{
    public class EmployeeManager : DataFactory<DataBaseCTX, Employee>
    {
        DataBaseCTX db = new DataBaseCTX();
        int Intake;




        public List<Employee> GetEmployees()
        {
            var xx = new EmployeeManager().GetAll();
            var y = xx.ToList();
            return y;
        }

        public EmployeetAutherization GetEmployeeData(string UserName)
        {
            // To get the Running Intake ...!
            // DateTime DateOfNow = DateTime.Now;
            // var Intake = db.Intakes.Where(x => x.StartDate <= DateOfNow && x.EndDate >= DateOfNow).Single().IntakeID;


            Intake = 36;

            var emp = new EmployeeManager().FindBy(x => x.UserName2 == UserName);
            var empmap = Mapper.Map<EmployeetAutherization>(emp);

            var EmpType = empmap.TypeID;
            string SP = "IsSupervisor";

            SqlParameter[] Params = {
                new SqlParameter("@ProgramID", System.Data.SqlDbType.Int){ Value = 4 },
                new SqlParameter("@IntakeID" , System.Data.SqlDbType.Int){ Value = Intake },
                new SqlParameter("@EmployeeID",System.Data.SqlDbType.Int){ Value = empmap.EmployeeID }
            };

            if (EmpType == 0)
            {
                return empmap; 
            }

            else if (EmpType == 1)
            {
                var Sp = new EmployeeManager().QueryData(SP, Params);
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
