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
    
    public partial class InstructorCourse
    {
        public int InstructorCourseID { get; set; }
        public int instructorID { get; set; }
        public Nullable<int> courseID { get; set; }
        public int TypeId { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
