using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace API_OAuth.Hubs
{
    public class examPrepearedHub : Hub
    {

        public void Hello()
        {
            Clients.All.hello();
        }
    }
}