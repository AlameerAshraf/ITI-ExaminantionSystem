using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Map
{
    public class EntityExamMap
    {
        public int Exam_Id { get; set; }
        public string Exam_Name { get; set; }
        public int? Number_Of_Questions { get; set; }
        public int? Exam_Duration { get; set; }
        public int? PlatformIntake_Id { get; set; }
        public virtual ICollection<QuestionsInExamMap> QuestionsInExams { get; set; }
    }
}
