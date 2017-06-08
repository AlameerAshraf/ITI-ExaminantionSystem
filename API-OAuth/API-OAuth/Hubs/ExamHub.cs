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
        public void Send(string name , string message)
        {
            Clients.All.broadcast(name, message);
        }

        public void SendToPerson(int id , string messages)
        {
            Clients.Client(Context.ConnectionId).broadcast2(messages);
        }

        public override Task OnConnected()
        {
            var Type = Context.QueryString["Type"];
            var id = Context.QueryString["Id"];

            if (Type == "2")
            {
                var StdObj = new StudentsConnectionId()
                {
                    Std_Id = int.Parse(id),
                    Connection_Ids = Guid.Parse(Context.ConnectionId)
                };
                nm.ListConnectedStudents(StdObj);
            }
            else
            {
                EmpConObj = new EmployeeConnectionId()
                {
                    Emp_Id = int.Parse(id),
                    Connection_Ids = Guid.Parse(Context.ConnectionId)
                };
                nm.ListConnectedEmployee(int.Parse(Type), EmpConObj);
            }
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled = true)
        {
            var Type = Context.QueryString["Type"];
            var id = Context.QueryString["Id"];

            var DisConnObj = new EmployeeConnectionId()
            {
                Connection_Ids = Guid.Parse(Context.ConnectionId),
                Emp_Id = int.Parse(id)
            };
            nm.UnListConnectedEmployee(int.Parse(Type), DisConnObj);
            return base.OnDisconnected(stopCalled);
        }
    }
}