﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.Owin;
using System.Web.Http.Controllers;
using System.Web.Http.OData.Extensions;
using DataAccessLayer;
using System.Web.Http.OData.Batch;
using Microsoft.Data.Edm;
using System.Web.Http.OData.Builder;
using DataAccessLayer.Models;
using BusineesLayer;
using Microsoft.Data.Edm.Library;
using System.Web.Hosting;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(API_OAuth.Startup))]

namespace API_OAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                };
                hubConfiguration.EnableDetailedErrors = true;
                map.RunSignalR(hubConfiguration);
            });
            HttpConfiguration config = new HttpConfiguration();
            app.UseCors(CorsOptions.AllowAll);

            ConfigureAuth(app);
            WebApiConfig.Register(config);
            config.Filters.Add(new System.Web.Http.AuthorizeAttribute());
            app.UseWebApi(config);

           // app.MapSignalR();

            //config.AddODataQueryFilter(new InlineCountQueryableAttribute());
            //ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            //builder.EntitySet<program>("programs");
            //builder.EntitySet<ProgramIntake>("ProgramIntakes");
            //builder.EntitySet<PlatfromIntake>("PlatfromIntakes");
            ////builder.EntitySet<program>("programs");
            //builder.EntitySet<Intake>("Intakes");
            //builder.EntitySet<subTrack>("subTracks");
            //builder.EntitySet<Employee>("Employees");
            //builder.EntitySet<StudentBasicData>("StudentBasicDatas");
            //builder.EntitySet<TrackSupervisor>("TrackSupervisors");
            //builder.EntitySet<TrackManual>("TrackManuals");
            //builder.EntitySet<Branch>("Branchs");
            //config.EnableQuerySupport();
            //config.Routes.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
            //AutoMapperConfiguration.Configure();
        }

    }
}
