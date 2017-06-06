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
    
    public partial class Platform
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Platform()
        {
            this.Employees = new HashSet<Employee>();
            this.PlatfromIntakes = new HashSet<PlatfromIntake>();
            this.InstructorCourseSims = new HashSet<InstructorCourseSim>();
        }
    
        public int PlatformID { get; set; }
        public string PlatformName { get; set; }
        public string NameAr { get; set; }
        public Nullable<int> Department_ID { get; set; }
        public Nullable<int> higherdept { get; set; }
        public System.Guid msrepl_tran_version { get; set; }
        public Nullable<bool> ISMonthPlat { get; set; }
        public Nullable<int> OwnerEmployeeID { get; set; }
    
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlatfromIntake> PlatfromIntakes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstructorCourseSim> InstructorCourseSims { get; set; }
    }
}
