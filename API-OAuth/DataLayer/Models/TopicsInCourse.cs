//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TopicsInCourse
    {
        public TopicsInCourse()
        {
            this.Questions = new HashSet<Questions>();
        }
    
        public int Topic_Id { get; set; }
        public string Topic_Name { get; set; }
        public int Crs_Id { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
