using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIAuthorizationServer.Constants
{
    public static class Paths
    {
        /// <summary>
        /// AuthorizationServer project should run on this URL
        /// </summary>
      //  public const string AuthorizationServerBaseAddress = "https://itisystems.gov.eg";
 public const string AuthorizationServerBaseAddress = "https://localhost:44304";
        /// <summary>
        /// ResourceServer project should run on this URL
        /// </summary>
        public const string ResourceServerBaseAddress = "http://apps.iti.gov.eg/ITI_API";
// public const string ResourceServerBaseAddress = "https://localhost:44375";
        /// <summary>
        /// ImplicitGrant project should be running on this specific port '38515'
        /// </summary>
     //   public const string ImplicitGrantCallBackPath = "http://localhost:38515/Home/SignIn";

        /// <summary>
        /// AuthorizationCodeGrant project should be running on this URL.
        /// </summary>
      //  public const string AuthorizeCodeCallBackPath = "http://localhost:38500/";

        public const string AuthorizePath = "/OAuth/Authorize";
        public const string TokenPath = "/OAuth/Token";
        public const string LoginPath = "/Account/Login";
        public const string LogoutPath = "/Account/Logout";
        public const string MePath = "/api/Me";
    }
}