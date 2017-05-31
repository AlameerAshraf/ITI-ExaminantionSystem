using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Map
{
    public partial class ProgramIntakeMap
    {
       
        public int IntakeID { get; set; }
        public int ProgramID { get; set; }
        public int ProgramIntakeID { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlatfromIntakeMap> PlatfromIntakes { get; set; }
        public virtual programMap program { get; set; }
        public virtual IntakeMap Intake { get; set; }
    }
}
