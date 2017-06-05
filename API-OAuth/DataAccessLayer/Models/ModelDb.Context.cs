﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DataBaseCTX : DbContext
    {
        public DataBaseCTX()
            : base("name=DataBaseCTX")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseEvaluationItem> CourseEvaluationItems { get; set; }
        public virtual DbSet<CourseInstanceDetail> CourseInstanceDetails { get; set; }
        public virtual DbSet<CourseManual> CourseManuals { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EvaluationCriteria> EvaluationCriterias { get; set; }
        public virtual DbSet<Intake> Intakes { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<PlatformDepartment> PlatformDepartments { get; set; }
        public virtual DbSet<PlatfromIntake> PlatfromIntakes { get; set; }
        public virtual DbSet<ProgramIntake> ProgramIntakes { get; set; }
        public virtual DbSet<program> programs { get; set; }
        public virtual DbSet<Student_Enrollment> Student_Enrollments { get; set; }
        public virtual DbSet<StudentBasicData> StudentBasicDatas { get; set; }
        public virtual DbSet<subTrack> subTracks { get; set; }
        public virtual DbSet<TrackManager> TrackManagers { get; set; }
        public virtual DbSet<TrackManual> TrackManuals { get; set; }
        public virtual DbSet<TrackSupervisor> TrackSupervisors { get; set; }
        public virtual DbSet<DepartmentsExam> DepartmentsExams { get; set; }
        public virtual DbSet<EmployeeNotification> EmployeeNotifications { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExternalInstructorAuthorization> ExternalInstructorAuthorizations { get; set; }
        public virtual DbSet<InstructorNotification> InstructorNotifications { get; set; }
        public virtual DbSet<InstructorsConnectionId> InstructorsConnectionIds { get; set; }
        public virtual DbSet<NewDateExamForPermittedStudent> NewDateExamForPermittedStudents { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<PointsInQuestion> PointsInQuestions { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionsInExam> QuestionsInExams { get; set; }
        public virtual DbSet<StudentAnswerQuestionInExam> StudentAnswerQuestionInExams { get; set; }
        public virtual DbSet<StudentMultiAnswersQuestion> StudentMultiAnswersQuestions { get; set; }
        public virtual DbSet<StudentNotification> StudentNotifications { get; set; }
        public virtual DbSet<StudentPermissionInExam> StudentPermissionInExams { get; set; }
        public virtual DbSet<StudentsConnectionId> StudentsConnectionIds { get; set; }
        public virtual DbSet<SupervisiorNotification> SupervisiorNotifications { get; set; }
        public virtual DbSet<SupervisiorsConnectionId> SupervisiorsConnectionIds { get; set; }
        public virtual DbSet<TopicsInCourse> TopicsInCourses { get; set; }
        public virtual DbSet<CoursesDataView> CoursesDataViews { get; set; }
        public virtual DbSet<Employee_metadata> Employee_metadata { get; set; }
        public virtual DbSet<EmployeeConnectionId> EmployeeConnectionIds { get; set; }
    
        [DbFunction("DataBaseCTX", "CoursePerBranchandtrack")]
        public virtual IQueryable<CoursePerBranchandtrack_Result> CoursePerBranchandtrack(Nullable<int> parameter1, Nullable<int> parameter2)
        {
            var parameter1Parameter = parameter1.HasValue ?
                new ObjectParameter("Parameter1", parameter1) :
                new ObjectParameter("Parameter1", typeof(int));
    
            var parameter2Parameter = parameter2.HasValue ?
                new ObjectParameter("Parameter2", parameter2) :
                new ObjectParameter("Parameter2", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<CoursePerBranchandtrack_Result>("[DataBaseCTX].[CoursePerBranchandtrack](@Parameter1, @Parameter2)", parameter1Parameter, parameter2Parameter);
        }
    
        public virtual ObjectResult<GetBranchByID_Result> GetBranchByID(Nullable<int> branchID)
        {
            var branchIDParameter = branchID.HasValue ?
                new ObjectParameter("BranchID", branchID) :
                new ObjectParameter("BranchID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBranchByID_Result>("GetBranchByID", branchIDParameter);
        }
    
        public virtual ObjectResult<GetBranchByName_Result> GetBranchByName(string branchName)
        {
            var branchNameParameter = branchName != null ?
                new ObjectParameter("BranchName", branchName) :
                new ObjectParameter("BranchName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBranchByName_Result>("GetBranchByName", branchNameParameter);
        }
    
        public virtual ObjectResult<GetBranchByPlatformIntakeID_Result> GetBranchByPlatformIntakeID(Nullable<int> platformIntakeID)
        {
            var platformIntakeIDParameter = platformIntakeID.HasValue ?
                new ObjectParameter("PlatformIntakeID", platformIntakeID) :
                new ObjectParameter("PlatformIntakeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBranchByPlatformIntakeID_Result>("GetBranchByPlatformIntakeID", platformIntakeIDParameter);
        }
    
        public virtual ObjectResult<GetCourseByInstructor_Result> GetCourseByInstructor(Nullable<int> instructorID)
        {
            var instructorIDParameter = instructorID.HasValue ?
                new ObjectParameter("InstructorID", instructorID) :
                new ObjectParameter("InstructorID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCourseByInstructor_Result>("GetCourseByInstructor", instructorIDParameter);
        }
    
        public virtual int GetCourseByIntake(Nullable<int> programIntakeID)
        {
            var programIntakeIDParameter = programIntakeID.HasValue ?
                new ObjectParameter("ProgramIntakeID", programIntakeID) :
                new ObjectParameter("ProgramIntakeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetCourseByIntake", programIntakeIDParameter);
        }
    
        public virtual ObjectResult<GetCourseByTrackId_Result> GetCourseByTrackId(Nullable<int> platformIntakeID)
        {
            var platformIntakeIDParameter = platformIntakeID.HasValue ?
                new ObjectParameter("PlatformIntakeID", platformIntakeID) :
                new ObjectParameter("PlatformIntakeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCourseByTrackId_Result>("GetCourseByTrackId", platformIntakeIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GetCourseInstanceID(Nullable<int> trackManualID)
        {
            var trackManualIDParameter = trackManualID.HasValue ?
                new ObjectParameter("TrackManualID", trackManualID) :
                new ObjectParameter("TrackManualID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetCourseInstanceID", trackManualIDParameter);
        }
    
        public virtual ObjectResult<GetEmpByPlatform_Result> GetEmpByPlatform(Nullable<int> platid)
        {
            var platidParameter = platid.HasValue ?
                new ObjectParameter("platid", platid) :
                new ObjectParameter("platid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetEmpByPlatform_Result>("GetEmpByPlatform", platidParameter);
        }
    
        public virtual ObjectResult<GetEmployee_Result> GetEmployee(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetEmployee_Result>("GetEmployee", usernameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<GetEmployeeByBranch_Result> GetEmployeeByBranch(Nullable<int> branchID)
        {
            var branchIDParameter = branchID.HasValue ?
                new ObjectParameter("BranchID", branchID) :
                new ObjectParameter("BranchID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetEmployeeByBranch_Result>("GetEmployeeByBranch", branchIDParameter);
        }
    
        public virtual ObjectResult<GetLastIntake_Result> GetLastIntake()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLastIntake_Result>("GetLastIntake");
        }
    
        public virtual ObjectResult<GetStudentByBranch_Result> GetStudentByBranch(Nullable<int> branchID)
        {
            var branchIDParameter = branchID.HasValue ?
                new ObjectParameter("BranchID", branchID) :
                new ObjectParameter("BranchID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentByBranch_Result>("GetStudentByBranch", branchIDParameter);
        }
    
        public virtual ObjectResult<GetStudentByIntake_Result> GetStudentByIntake(Nullable<int> programIntakeID)
        {
            var programIntakeIDParameter = programIntakeID.HasValue ?
                new ObjectParameter("ProgramIntakeID", programIntakeID) :
                new ObjectParameter("ProgramIntakeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentByIntake_Result>("GetStudentByIntake", programIntakeIDParameter);
        }
    
        public virtual ObjectResult<GetStudentByPlatformID_Result> GetStudentByPlatformID(Nullable<int> platformID, Nullable<int> branchid)
        {
            var platformIDParameter = platformID.HasValue ?
                new ObjectParameter("PlatformID", platformID) :
                new ObjectParameter("PlatformID", typeof(int));
    
            var branchidParameter = branchid.HasValue ?
                new ObjectParameter("branchid", branchid) :
                new ObjectParameter("branchid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentByPlatformID_Result>("GetStudentByPlatformID", platformIDParameter, branchidParameter);
        }
    
        public virtual ObjectResult<GetStudentDetails_Result> GetStudentDetails(Nullable<int> studentID)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentDetails_Result>("GetStudentDetails", studentIDParameter);
        }
    
        public virtual ObjectResult<string> GetStudentGrade(Nullable<int> studentID, Nullable<int> evalID, Nullable<int> courseinstanceid)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            var evalIDParameter = evalID.HasValue ?
                new ObjectParameter("EvalID", evalID) :
                new ObjectParameter("EvalID", typeof(int));
    
            var courseinstanceidParameter = courseinstanceid.HasValue ?
                new ObjectParameter("Courseinstanceid", courseinstanceid) :
                new ObjectParameter("Courseinstanceid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetStudentGrade", studentIDParameter, evalIDParameter, courseinstanceidParameter);
        }
    
        public virtual ObjectResult<GetTrackByBranch_Result> GetTrackByBranch(Nullable<int> branchID)
        {
            var branchIDParameter = branchID.HasValue ?
                new ObjectParameter("BranchID", branchID) :
                new ObjectParameter("BranchID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTrackByBranch_Result>("GetTrackByBranch", branchIDParameter);
        }
    
        public virtual ObjectResult<IsSupervisor_Result> IsSupervisor(Nullable<int> programID, Nullable<int> intakeID, Nullable<int> employeeID)
        {
            var programIDParameter = programID.HasValue ?
                new ObjectParameter("ProgramID", programID) :
                new ObjectParameter("ProgramID", typeof(int));
    
            var intakeIDParameter = intakeID.HasValue ?
                new ObjectParameter("IntakeID", intakeID) :
                new ObjectParameter("IntakeID", typeof(int));
    
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<IsSupervisor_Result>("IsSupervisor", programIDParameter, intakeIDParameter, employeeIDParameter);
        }
    
        public virtual ObjectResult<GetCoursePerBranchandtrack_Result> GetCoursePerBranchandtrack(Nullable<int> branch, Nullable<int> subTrack)
        {
            var branchParameter = branch.HasValue ?
                new ObjectParameter("Branch", branch) :
                new ObjectParameter("Branch", typeof(int));
    
            var subTrackParameter = subTrack.HasValue ?
                new ObjectParameter("SubTrack", subTrack) :
                new ObjectParameter("SubTrack", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCoursePerBranchandtrack_Result>("GetCoursePerBranchandtrack", branchParameter, subTrackParameter);
        }
    
        public virtual ObjectResult<GetInstIntake_Result> GetInstIntake(Nullable<int> course, Nullable<int> intake, Nullable<int> subTrack, Nullable<int> program)
        {
            var courseParameter = course.HasValue ?
                new ObjectParameter("Course", course) :
                new ObjectParameter("Course", typeof(int));
    
            var intakeParameter = intake.HasValue ?
                new ObjectParameter("Intake", intake) :
                new ObjectParameter("Intake", typeof(int));
    
            var subTrackParameter = subTrack.HasValue ?
                new ObjectParameter("SubTrack", subTrack) :
                new ObjectParameter("SubTrack", typeof(int));
    
            var programParameter = program.HasValue ?
                new ObjectParameter("Program", program) :
                new ObjectParameter("Program", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetInstIntake_Result>("GetInstIntake", courseParameter, intakeParameter, subTrackParameter, programParameter);
        }
    
        public virtual ObjectResult<InstructorCurrent_Result> InstructorCurrent(Nullable<int> employeeID, Nullable<System.DateTime> currentDate)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("EmployeeID", employeeID) :
                new ObjectParameter("EmployeeID", typeof(int));
    
            var currentDateParameter = currentDate.HasValue ?
                new ObjectParameter("CurrentDate", currentDate) :
                new ObjectParameter("CurrentDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<InstructorCurrent_Result>("InstructorCurrent", employeeIDParameter, currentDateParameter);
        }
    }
}
