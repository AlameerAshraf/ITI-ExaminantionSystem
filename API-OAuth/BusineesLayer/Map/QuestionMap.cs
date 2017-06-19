﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusineesLayer.Map
{
   public class QuestionMap
    {
        public int Ques_Id { get; set; }
        public int Ques_Type { get; set; }
        public string Ques_Content { get; set; }
        public virtual ICollection<QuestionAnswerMap> QuestionAnswers { get; set; }

    }
}
