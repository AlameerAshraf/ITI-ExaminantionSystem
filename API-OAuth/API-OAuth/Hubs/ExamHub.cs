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
        static List<Users> Data = new List<Users>();
        public void Send(string name , string message)
        {
            Clients.All.broadcast(name, message);
        }

        public void SendToPerson(int id , string messages)
        {
            Users i =  Data.Find(W => W.id == id);
            Clients.Client(i.Cid).broadcast2(messages);
        }

        public override Task OnConnected()
        {
            //StudentMananger std = new StudentMananger();
            //var t = std.GetStudents();
           // var username = Context.User.Identity.Name; 
            var myQS = Context.QueryString["name"];
            var Track = Context.QueryString["Track"];
            var id = Context.QueryString["Id"];
            var cid = Context.ConnectionId;
            Data.Add(new Users { id = int.Parse(id), Cid = cid });
            return base.OnConnected();
        }
    }

    public class Users
    {
        public int id { get; set; }
        public string Cid { get; set; }
    }
}