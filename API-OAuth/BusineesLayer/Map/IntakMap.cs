using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Map
{
    public partial class IntakeMap
    {
        public int IntakeID { get; set; }
        public Nullable<int> IntakeNo { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string IntakeName { get; set; }
        public virtual ICollection<ProgramIntake> ProgramIntakes { get; set; }
    }
}
