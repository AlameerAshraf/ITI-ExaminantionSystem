//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PointsInQuestion
    {
        public int Point_Id { get; set; }
        public int Ques_Id { get; set; }
        public int Point_Question_Id { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual Question Question1 { get; set; }
    }
}