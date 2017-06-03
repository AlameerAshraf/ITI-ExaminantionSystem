using ITIAuthorizationServer.Constants;
using ITIAuthorizationServer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Owin;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using ITIAuthorizationServer.AccessData;
using DataAccessLayer.Models;
using Client = ITIAuthorizationServer.Models.Client;
using BusineesLayer.Managers;

namespace ITIAuthorizationServer
{
    //grant_type=password&username=demo1&password=demo1&Client_Id=123456&client_secret=abcdef&logtype=1&client_Type=android&clientOsVersion=19
    public partial class Startup
    {
        private int loginType = 0;
        private string client_Type = "";
        private string clientOsVersion = "";
        public static List<Client> InmemoryClient
        {
            get { return InMemortClient(); }
        }


        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AuthorizeEndpointPath = new PathString(Paths.AuthorizePath),
                TokenEndpointPath = new PathString(Paths.TokenPath),
                ApplicationCanDisplayErrors = true,
#if DEBUG
                AllowInsecureHttp = true,
#endif
                Provider = new OAuthAuthorizationServerProvider
                {
                    OnValidateClientRedirectUri = ValidateClientRedirectUri,
                    OnValidateClientAuthentication = ValidateClientAuthentication,
                    OnGrantResourceOwnerCredentials = GrantResourceOwnerCredentials,
                    OnGrantClientCredentials = GrantClientCredetails,
                    OnTokenEndpoint = TokenEndpoint
                },

                AuthorizationCodeProvider = new AuthenticationTokenProvider
                {
                    OnCreate = CreateAuthenticationCode,
                    OnReceive = ReceiveAuthenticationCode,
                },

                RefreshTokenProvider = new AuthenticationTokenProvider
                {
                    OnCreate = CreateRefreshToken,
                    OnReceive = ReceiveRefreshToken,
                },
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(10)
            });
        }

        private Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            //if (context.ClientId == Clients.Client1.Id)
            //{
            //    context.Validated(Clients.Client1.RedirectUrl);
            //}
            //else if (context.ClientId == Clients.Client2.Id)
            //{
            //    context.Validated(Clients.Client2.RedirectUrl);
            //}
            context.Validated(InmemoryClient.FirstOrDefault(x => x.ClientId == context.ClientId).ClientUri);
            return Task.FromResult(0);
        }

        public static List<Models.Client> InMemortClient()
        {
            ITIAuthorizationServerEntities db = new ITIAuthorizationServerEntities();
            return db.Clients.Where(x => x.Enabled.Value == true).ToList();
        }
        private Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;

            string clientSecret;

            loginType = int.Parse(context.Parameters["logtype"]);
            client_Type = context.Parameters["client_Type"];
            clientOsVersion = context.Parameters["clientOsVersion"];
            if (context.TryGetBasicCredentials(out clientId, out clientSecret) ||
                context.TryGetFormCredentials(out clientId, out clientSecret))
            {
                var xx = InmemoryClient;
                if (clientId == InmemoryClient.FirstOrDefault(x => x.ClientId == context.ClientId).ClientId && clientSecret == InmemoryClient.FirstOrDefault(x => x.ClientId == context.ClientId).ClientSecrets)
                {
                    context.Validated();
                }

            }
            return Task.FromResult(0);
        }

        private Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            var emp = (Employee) null;
            //employee
            if (loginType == 1)
            {
                var Repos = new UsersRepo();
                emp = Repos.GetEmps().FirstOrDefault(x => x.IPassword == context.Password && x.UserName2 == context.UserName);

                if (emp != null)
                {
                    identity.AddClaim(new Claim("role", "user"));
                    identity.AddClaim(new Claim("guid", emp.EmployeeID.ToString()));
                    var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "UserID", emp.EmployeeID.ToString()
                    },
                    {
                        "EmployeeName", emp.InstructorName
                    }
                });
                    var ticket = new AuthenticationTicket(identity, props);
                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return Task.FromResult<object>(null);
                }
            }

            //sudent
            var student = (StudentAutherization) null;
            if (loginType == 2)
            {
                var Repos = new UsersRepo();
                student = Repos.GetStds().FirstOrDefault(x => x.userpwd == context.Password && x.Username == context.UserName);
                
                if (student != null)
                {
                    identity.AddClaim(new Claim("role", "student"));
                    identity.AddClaim(new Claim("guid", student.StudentID.ToString()));
                    var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "StudentID", student.StudentID.ToString()
                    },
                    {
                        "StudentName", student.englishname
                    },

                    {
                        "TrackID", student.SubTrackID.ToString()
                    }
                });
                    var ticket = new AuthenticationTicket(identity, props);
                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return Task.FromResult<object>(null);
                }
            }

     
            return Task.FromResult<object>(null);
        }

        private Task GrantClientCredetails(OAuthGrantClientCredentialsContext context)
        {
            var identity = new ClaimsIdentity(new GenericIdentity(context.ClientId, OAuthDefaults.AuthenticationType), context.Scope.Select(x => new Claim("urn:oauth:scope", x)));

            context.Validated(identity);

            return Task.FromResult(0);
        }


        private readonly ConcurrentDictionary<string, string> _authenticationCodes =
            new ConcurrentDictionary<string, string>(StringComparer.Ordinal);

        private void CreateAuthenticationCode(AuthenticationTokenCreateContext context)
        {
            context.SetToken(Guid.NewGuid().ToString("n") + Guid.NewGuid().ToString("n"));
            _authenticationCodes[context.Token] = context.SerializeTicket();
        }

        private void ReceiveAuthenticationCode(AuthenticationTokenReceiveContext context)
        {
            string value;

            if (_authenticationCodes.TryRemove(context.Token, out value))
            {
                context.DeserializeTicket(value);
            }
        }

        private void CreateRefreshToken(AuthenticationTokenCreateContext context)
        {
            context.SetToken(context.SerializeTicket());
        }

        private void ReceiveRefreshToken(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }
        public Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }

}