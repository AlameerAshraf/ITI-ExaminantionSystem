using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Map
{
    public partial class CourseManualMap
    {
        public int courseManualID { get; set; }
        public int? CourseID { get; set; }
        public int? totalGrade { get; set; }
        public int? minGrade { get; set; }
        public int? labsNumber { get; set; }
        public int? lecturesNumber { get; set; }
        public int? lech { get; set; }
        public int? selfh { get; set; }
        public int? labh { get; set; }
        public int? credit { get; set; }
        public string coursenote { get; set; }
        public string swReq { get; set; }
        public string hwReq { get; set; }
        public string CourseCode { get; set; }
        public string CourseDescription { get; set; }
        public string CourseObjective { get; set; }
        public string CourseContent { get; set; }
        public int? ProgramIntakeID { get; set; }

        public virtual CourseMap Course { get; set; }
       
        public virtual ICollection<TrackManual> TrackManuals { get; set; }
    }
}
