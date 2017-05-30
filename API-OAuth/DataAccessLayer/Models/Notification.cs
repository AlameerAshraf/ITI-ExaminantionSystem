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
    
    public partial class Notification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Notification()
        {
            this.EmployeeNotifications = new HashSet<EmployeeNotification>();
            this.InstructorNotifications = new HashSet<InstructorNotification>();
            this.StudentNotifications = new HashSet<StudentNotification>();
            this.SupervisiorNotifications = new HashSet<SupervisiorNotification>();
        }
    
        public int Notification_Id { get; set; }
        public string Notification_Text { get; set; }
        public Nullable<bool> Is_Read { get; set; }
        public Nullable<System.DateTime> Creation_Time { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeNotification> EmployeeNotifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstructorNotification> InstructorNotifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentNotification> StudentNotifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupervisiorNotification> SupervisiorNotifications { get; set; }
    }
}
