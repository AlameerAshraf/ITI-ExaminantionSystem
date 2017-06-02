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
        int Intake = 0;


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

            var emp = FindBy(x => x.UserName2 == UserName);
            var empmap = Mapper.Map<EmployeetAutherization>(emp);
            var EmpType = empmap.TypeID;


            string SP_Current = "exec [dbo].[InstructorCurrent] @EmployeeID,@CurrentDate";
            SqlParameter[] Params_Current = {
                new SqlParameter("@EmployeeID",empmap.EmployeeID),
                new SqlParameter("@CurrentDate",DateTime.Now)
            };

            string SP_supervision = "exec [dbo].[IsSupervisor] @ProgramID,@IntakeID,@EmployeeID";
            SqlParameter[] Params_supervision = {
                new SqlParameter("@ProgramID",4),
                new SqlParameter("@IntakeID" ,Intake),
                new SqlParameter("@EmployeeID",empmap.EmployeeID)
            };

            if (EmpType == 0)
            {
                empmap.supervisiedTrackId = null; 
                return empmap; 
            }
            else
            {
                List<IsSupervisor> Sp = db.Database.SqlQuery<IsSupervisor>(SP_supervision, Params_supervision).ToList();
                empmap.supervisiedTrackId = Sp[0].TrackId;
                return empmap;
            }
        }




    }

    public class IsSupervisor
    {
        public int? TrackId { get; set; }
        public int? BranchId { get; set; }
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
        public int? supervisiedTrackId { get; set; }
    }
}
