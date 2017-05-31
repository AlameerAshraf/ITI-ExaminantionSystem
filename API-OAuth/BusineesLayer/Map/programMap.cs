using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Map
{
    public partial class programMap
    {
        public int programId { get; set; }
        public string programName { get; set; }
        public string programnotes { get; set; }
        public virtual ICollection<IntakeMap> Intake { get; set; }
        public virtual ICollection<ProgramIntakeMap> ProgramIntakes { get; set; }
    }
    
}
