using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Map
{
    public partial class BranchMap
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string arabicname { get; set; }
       
        public int? trainbranchid { get; set; }
        
        public virtual ICollection<PlatfromIntake> PlatfromIntakes { get; set; }
    }
}
