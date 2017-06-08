using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using AutoMapper;
using System.Data.SqlClient;
using System.Globalization;

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
            //36 for test 
            DateTime DateOfNow = DateTime.ParseExact("01/10/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture);


            Intake = 36;

            var emp = FindBy(x => x.UserName2 == UserName);
            var empmap = Mapper.Map<EmployeetAutherization>(emp);
            var EmpType = empmap.TypeID;

            if (EmpType == 0)
            {
                empmap.supervisiedTrackId = null; 
                return empmap; 
            }
            else
            {
                // Get Instructor Porgrams ... !

#region
                string SP_Current = "exec [dbo].[InstructorCurrent] @EmployeeID,@CurrentDate";
                List<SqlParameter> Params_Current = new List<SqlParameter>() {
                    new SqlParameter("@EmployeeID",empmap.EmployeeID),
                    new SqlParameter("@CurrentDate",DateOfNow)
                };
                List<InstructorCurrentProgramData> InstructorcurrentPros = QueryData<InstructorCurrentProgramData>(SP_Current, Params_Current);
                empmap.InstructorPorgrams = InstructorcurrentPros;
                #endregion


                // Which Program the instructor is supervisior in  ... !
 #region
                string SP_supervision = "exec [dbo].[IsSupervisor] @ProgramID,@IntakeID,@EmployeeID";
                List<SqlParameter> Params_supervision = new List<SqlParameter>() {
                        new SqlParameter("@IntakeID" ,Intake),
                        new SqlParameter("@EmployeeID",empmap.EmployeeID)
                 };

                #endregion

                foreach (var item in empmap.InstructorPorgrams)
                {
                    Params_supervision.Add(new SqlParameter("@ProgramID", item.ProgramID));
                    List <IsSupervisor> _Supervision = QueryData<IsSupervisor>(SP_supervision, Params_supervision);
                    empmap.supervisiedTrackId = _Supervision[0].TrackId;
                }
#region
                // Which Courses He Teaches 
                string SP_courses = "exec [dbo].[InstructorCoursesEnrolled] @intakeid,@EmployeeID,@ProgramID";
                List<SqlParameter> Params_courses = new List<SqlParameter>() {
                        new SqlParameter("@EmployeeID",empmap.EmployeeID),
                        new SqlParameter("@intakeid",Intake)
                 };

                foreach (var item in empmap.InstructorPorgrams)
                {
                    Params_courses.Add(new SqlParameter("@ProgramID", item.ProgramID));
                    List<InstructorCourses> _courses = QueryData<InstructorCourses>(SP_courses, Params_courses);
                    empmap.InstructorCourses = _courses;
                }

                #endregion

                return empmap;
            }
        }

        public object IsExternal(int Id)
        {
            Employee Obj = FindBy(e => e.EmployeeID == Id);
            var mapped = Mapper.Map<EmployeetAutherization>(Obj);
            var Role = mapped.RoleID;
            if(Role == 1)
            {
                return new { Email = 0 };
            }
            else if (Role == 2)
            {
                var mail = mapped.Mail;
                return new { Email = "alamiir.ashraf@gmail.com" };
            }
            return false; 
        }



        // Running Queries ! 
        public List<T> QueryData<T>(string QueryString , List<SqlParameter> Params)
        {
            SqlParameter[] Paramters = Params.ToArray();
            List<T> _Sp = db.Database.SqlQuery<T>(QueryString, Paramters).ToList();
            return _Sp;
        }




    }
    public class IsSupervisor
    {
        public int? TrackId { get; set; }
        public int? BranchId { get; set; }
    }
    public class InstructorCurrentProgramData
    {
        public int? ProgramID { get; set; }
        public int? IntakeID { get; set; }
    }
    public class InstructorCourses
    {
        public int CourseID { get; set; }
        public int subtrackID { get; set; }
        public int PlatformID { get; set; }
    }
    public class EmployeetAutherization
    {
        public int EmployeeID { get; set; }
        public string InstructorName { get; set; }
        public int BranchID { get; set; }
        public string IPassword { get; set; }
        public string UserName2 { get; set; }
        public int? RoleID { get; set; }
        public int? PlatformID { get; set; }
        public int? TypeID { get; set; }
        public int? supervisiedTrackId { get; set; }
        public string Mail { get; set; }
        public List<InstructorCurrentProgramData> InstructorPorgrams { get; set; }
        public List<InstructorCourses> InstructorCourses { get; set; }
    }

}
