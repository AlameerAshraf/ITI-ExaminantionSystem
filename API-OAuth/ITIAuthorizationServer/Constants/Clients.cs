using ITIAuthorizationServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIAuthorizationServer.Constants
{  
    public static class Clients
    {
        public readonly static Client Client1 = new Client
        {
            Id = "123456",
            Secret = "abcdef"
        //    RedirectUrl = Paths.AuthorizeCodeCallBackPath
        };

        public readonly static Client Client2 = new Client
        {
            Id = "7890ab",
            Secret = "7890ab"
         //   RedirectUrl = Paths.ImplicitGrantCallBackPath
        };
      public static Models.Client GetClintBYID(string clintid)
        {
            ITIAuthorizationServerEntities db = new ITIAuthorizationServerEntities();
            return db.Clients.FirstOrDefault(x => x.ClientId == clintid);
        }

    }

    public class Client
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string RedirectUrl { get; set; }
    }
}