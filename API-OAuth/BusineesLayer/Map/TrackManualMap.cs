using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Map
{
    public partial class TrackManualMap
    {
        public int TrackManualID { get; set; }
        public int? CourseManualID { get; set; }
        public int? PlatformIntakeID { get; set; }
        public bool? IsElective { get; set; }
        public int? ElecetiveGroupID { get; set; }

        public virtual CourseManualMap CourseManual { get; set; }
       // public virtual PlatfromIntake PlatfromIntake { get; set; }
    }
}
