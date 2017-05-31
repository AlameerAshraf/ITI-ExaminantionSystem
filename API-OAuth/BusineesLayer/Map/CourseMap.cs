using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Map
{
    public partial class CourseMap
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int? CategoryID { get; set; }
        public virtual ICollection<CourseManualMap> CourseManuals { get; set; }
    }
}
