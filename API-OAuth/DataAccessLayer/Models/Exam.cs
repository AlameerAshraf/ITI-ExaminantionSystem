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
    
    public partial class Exam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exam()
        {
            this.DepartmentsExams = new HashSet<DepartmentsExam>();
            this.NewDateExamForPermittedStudents = new HashSet<NewDateExamForPermittedStudent>();
            this.QuestionsInExams = new HashSet<QuestionsInExam>();
            this.StudentAnswerQuestionInExams = new HashSet<StudentAnswerQuestionInExam>();
            this.StudentPermissionInExams = new HashSet<StudentPermissionInExam>();
        }
    
        public int Exam_Id { get; set; }
        public string Exam_Name { get; set; }
        public Nullable<int> Number_Of_Questions { get; set; }
        public Nullable<int> Ins_Id { get; set; }
        public Nullable<bool> Exam_Corrected { get; set; }
        public Nullable<int> Exam_Duration { get; set; }
        public string Exam_FullDegree { get; set; }
        public Nullable<int> Course_Id { get; set; }
    
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepartmentsExam> DepartmentsExams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewDateExamForPermittedStudent> NewDateExamForPermittedStudents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionsInExam> QuestionsInExams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAnswerQuestionInExam> StudentAnswerQuestionInExams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentPermissionInExam> StudentPermissionInExams { get; set; }
        public virtual Course Course { get; set; }
    }
}
