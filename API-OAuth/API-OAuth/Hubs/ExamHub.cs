using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using DataAccessLayer.Models;
using BusineesLayer.Managers;

namespace API_OAuth.Hubs 
{
    public class ExamHub : Hub
    {
        NotificationManager nm = new NotificationManager();
        EmployeeConnectionId EmpConObj;


        public void NotifyExamSchedule(int Traget_Instructor, string SenderName, string Message, string Clicked_Url)
        {

            nm.RegisterNotification(Traget_Instructor, Message, 1);
            ConnectionState IsConnected = nm.ConnectionIdData(Traget_Instructor, 1);

            if (IsConnected.ConnectionId != null)
            {
                var Cid = IsConnected.ConnectionId.ToString();
                Clients.Client(Cid).ReceiveExamSchedule(SenderName, Message, Clicked_Url);
            }
        }
        public void Send(string name , string message)
        {
            Clients.All.broadcast(name, message);
        }

        public void SendToPerson(int id , string messages)
        {
            Clients.All.broadcast(messages);
        }

        public override Task OnConnected()
        {
            var LoggedEntity = Context.QueryString["LoggedEntity"];
            var id = Context.QueryString["Id"];
            var Type = int.Parse(Context.QueryString["Type"]);

            if (LoggedEntity == "L" )
            {
                var StdObj = new StudentsConnectionId()
                {
                    Std_Id = int.Parse(id),
                    Connection_Ids = Guid.Parse(Context.ConnectionId)
                };

                nm.ListConnectedStudents(StdObj);
            }
            else if (LoggedEntity == "W")
            {
                EmpConObj = new EmployeeConnectionId()
                {
                    Emp_Id = int.Parse(id),
                    Connection_Ids = Guid.Parse(Context.ConnectionId)
                };
                nm.ListConnectedEmployee(Type, EmpConObj);
            }
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled = true)
        {
            var LoggedEntity = Context.QueryString["LoggedEntity"];
            var id = Context.QueryString["Id"];
            var Type = int.Parse(Context.QueryString["Type"]);

            var DisConnObj = new EmployeeConnectionId()
            {
                Connection_Ids = Guid.Parse(Context.ConnectionId),
                Emp_Id = int.Parse(id)
            };

            if (LoggedEntity == "W")
            {
                nm.UnListConnectedEmployee(Type, DisConnObj);
            }
            else if (LoggedEntity == "L")
            {
                nm.UnListConnectedEmployee(Type, DisConnObj);
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}