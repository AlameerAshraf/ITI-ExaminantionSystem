using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusineesLayer.Map
{
    class QuestionMap
    {
        public int Ques_Id { get; set; }
        public int Ques_Type { get; set; }
        public string Ques_Content { get; set; }
        public Nullable<bool> Ques_Activation { get; set; }
        public Nullable<int> Ques_Level { get; set; }
        public Nullable<int> Ques_Repetation { get; set; }
        public Nullable<int> Topic_Id { get; set; }
        public Nullable<int> Ins_Id { get; set; }
        public Nullable<bool> Points_Indicator { get; set; }

        public string Topic_Name { get; set; }
    }
}
