using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using AutoMapper;
using BusineesLayer.Map;
using System.Data.SqlClient;

namespace BusineesLayer.Managers
{
    public class StudentMananger : DataFactory<DataBaseCTX , StudentBasicData>
    {
        DataBaseCTX db = new DataBaseCTX();

        public List<StudentAutherization> GetStudents()
        {
            List<StudentBasicData> xx = new StudentMananger().GetAll().ToList();
            var ts = Mapper.Map<List<StudentAutherization>>(xx);
            return ts;
        }

        public StudentMap GetStudentData(string UserName)
        {
            StudentBasicData std_data = new StudentMananger().FindBy(x => x.Username == UserName);
            StudentMap stds = Mapper.Map<StudentMap>(std_data);

            #region

            string SP_Current = "exec [dbo].[GetStudentsCourses] @Std_Id";
            List<SqlParameter> Params_Current = new List<SqlParameter>() {
                    new SqlParameter("@Std_Id",stds.StudentID),
                };
            List<Student_EnrollmentMap> InstructorcurrentPros = QueryData<Student_EnrollmentMap>(SP_Current, Params_Current);
            stds.Student_Enrollment = InstructorcurrentPros;
            #endregion

            var Plat = db.PlatfromIntakes.Where(t => t.PlatformIntakeID == stds.PlatformIntakeID).SingleOrDefault();
            int? BranchID = Plat.BranchID;
            int? TrackId = Plat.SubTrackID;

            stds.TrackId = TrackId;
            stds.BranchID = BranchID; 


            return stds; 
        }


        public List<T> QueryData<T>(string QueryString, List<SqlParameter> Params)
        {
            SqlParameter[] Paramters = Params.ToArray();
            List<T> _Sp = db.Database.SqlQuery<T>(QueryString, Paramters).ToList();
            return _Sp;
        }




    }

    public class StudentAutherization
    {
        public int StudentID { get; set; }
        public string englishname { get; set; }
        public string Username { get; set; }
        public string userpwd { get; set; }

    }
}


