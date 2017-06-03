using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace App_iti.Hubs
{
    public class examPreperationHub : Hub
    {

        public override Task OnConnected()
        {
            return base.OnConnected();
            Context.QueryString
            string s = Context.ConnectionId;

        }


        //protected override Task OnConnected(IRequest request, string connectionId)
        //{
        //    return Connection.Send(connectionId, "Welcome!");
        //}

        //protected override Task OnReceived(IRequest request, string connectionId, string data)
        //{
        //    return Connection.Broadcast(data);
        //}
    }
}