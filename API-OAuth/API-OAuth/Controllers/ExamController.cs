using BusineesLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API_OAuth.Controllers
{
    public class ExamController : ApiController
    {
        ExamManager Ex = new ExamManager();
        public List<ExamMetaData> GetSchedulesExams(int PlatformId)
        {
            return Ex.GetScheduledExams(PlatformId);
        }

        public ExamMetaData GetExamData(int Ex_Id)
        {
            return Ex.GetExamDetails(Ex_Id); 
        }
    }
}