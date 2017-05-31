using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Map
{
    public partial class subTrackMap
    {
       

        public int subtrackID { get; set; }
        public string subtrackName { get; set; }
        public string code { get; set; }


        public virtual ICollection<PlatfromIntakeMap> PlatfromIntakes { get; set; }
    }
}
