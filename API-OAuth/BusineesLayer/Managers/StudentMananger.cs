using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using AutoMapper;
using BusineesLayer.Map;

namespace BusineesLayer.Managers
{
    public class StudentMananger : DataFactory<DataBaseCTX , StudentBasicData>
    {
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
            return stds; 
        }

    





    }

    public class StudentAutherization
    {
        public int StudentID { get; set; }
        public string englishname { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int SubTrackID { get; set; }
        public string Username { get; set; }
        public string userpwd { get; set; }
    }
}


