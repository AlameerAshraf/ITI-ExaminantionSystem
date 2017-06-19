using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusineesLayer.Map
{
    public partial class QuestionAnswerMap
    {
        public int Ques_Id { get; set; }
        public int Answer_Id { get; set; }
        public string Answer_Content { get; set; }
        public Nullable<bool> Is_It_RightAnswer { get; set; }
    }
}
