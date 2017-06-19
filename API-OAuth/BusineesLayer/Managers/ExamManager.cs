using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using BusineesLayer.Map;
using AutoMapper;

namespace BusineesLayer.Managers
{
    public class ExamManager 
    {
        DataBaseCTX CTX = new DataBaseCTX();
        public List<ExamMetaData> GetScheduledExams(int PlatformID)
        {
            List<ExamMetaData> Li = (from Ex in CTX.Exams
                                     join Ex_Dep in CTX.DepartmentsExams on Ex.Exam_Id equals Ex_Dep.Exam_Id
                                     join Crs in CTX.Courses on Ex.Course_Id equals Crs.CourseID
                                     where Ex_Dep.PlatformIntakeID == PlatformID 
                                     select new ExamMetaData { Course_Name = Crs.CourseName, Exam_Degree = Ex.Exam_FullDegree, Exam_Duration = Ex.Exam_Duration, Exam_Id = Ex.Exam_Id, Exam_Name = Ex.Exam_Name, Date = Ex_Dep.Exam_Date , Course_Id = Crs.CourseID }).ToList();

            return Li; 
        }

        public ExamMetaData GetExamDetails(int Exam_Id_V)
        {
            ExamMetaData Ex = new ExamMetaData();
            Ex = (from Exe in CTX.Exams
                  join Ex_Dep in CTX.DepartmentsExams on Exe.Exam_Id equals Ex_Dep.Exam_Id
                  join Crs in CTX.Courses on Exe.Course_Id equals Crs.CourseID
                  where Exe.Exam_Id == Exam_Id_V
                  select new ExamMetaData { Exam_Id = Exe.Exam_Id, Course_Name = Crs.CourseName, Date = Ex_Dep.Exam_Date, Exam_Degree = Exe.Exam_FullDegree, Exam_Duration = Exe.Exam_Duration, Exam_Name = Exe.Exam_Name , Course_Id = Crs.CourseID}).Single();


            return Ex; 

        }

        public EntityExamMap GetExam(int Exam_Id)
        {
            var Exam = CTX.Exams.Where(r => r.Exam_Id == Exam_Id).SingleOrDefault();
            var ret = Mapper.Map<EntityExamMap>(Exam);
            return ret; 
        }
    }


    public class ExamMetaData
    {
        public int Exam_Id { get; set; }
        public string Exam_Name { get; set; }
        public int? Exam_Duration { get; set; }
        public string Exam_Degree { get; set; }
        public string Course_Name { get; set; }
        public DateTime? Date { get; set; }
        public int Course_Id { get; set; }
    }



    
}
