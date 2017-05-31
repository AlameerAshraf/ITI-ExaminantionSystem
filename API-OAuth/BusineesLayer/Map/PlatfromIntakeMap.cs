using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Map
{
    public partial class PlatfromIntakeMap
    {
        public int PlatformIntakeID { get; set; }
        public int? BranchID { get; set; }
        public int? SubTrackID { get; set; }
        public int? ProgramIntakeID { get; set; }
        public int? OwnedBy { get; set; }
        public string GraduateProfile { get; set; }

        public virtual subTrackMap subTrack { get; set; }
     
        public virtual ICollection<StudentMap> StudentBasicDatas { get; set; }
       
        public virtual ICollection<TrackManualMap> TrackManuals { get; set; }
        public virtual BranchMap Branch { get; set; }
        public virtual ProgramIntakeMap ProgramIntake { get; set; }


        public virtual ICollection<TrackSupervisor> TrackSupervisors { get; set; }
    }
}
