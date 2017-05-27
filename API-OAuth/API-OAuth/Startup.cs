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
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(API_OAuth.Startup))]

namespace API_OAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // ConfigureAuth(app);
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            // ConfigureOAuth(app);
            ConfigureAuth(app);
            WebApiConfig.Register(config);
            
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            config.Filters.Add(new AuthorizeAttribute());
            app.UseWebApi(config);
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
