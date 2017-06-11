using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Map
{
    public partial class StudentMap
    {
        public int StudentID { get; set; }
        public string englishname { get; set; }
        public string arabicname { get; set; }
        public string ApplicationNo { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int SubTrackID { get; set; }
        public DateTime? DateOB { get; set; }
        public int PlatformIntakeID { get; set; }
        public int? BranchID { get; set; }
        public int? TrackId { get; set; }
        public string Username { get; set; }
        public string userpwd { get; set; }
        public virtual ICollection<Student_EnrollmentMap> Student_Enrollment { get; set; }
    }
}
