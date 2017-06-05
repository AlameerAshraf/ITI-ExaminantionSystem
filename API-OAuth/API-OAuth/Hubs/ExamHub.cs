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
            var Track = Context.QueryString["Track"];
            var id = Context.QueryString["Id"];

            EmpConObj = new EmployeeConnectionId();
            EmpConObj.Emp_Id = int.Parse(id);
            EmpConObj.Connection_Ids = Guid.Parse(Context.ConnectionId);

          //  nm.ListConnectedEmployee(int.Parse(Type), EmpConObj);


            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled = true)
        {
            var t = Context.ConnectionId; 
            return base.OnDisconnected(stopCalled);
        }
    }
}