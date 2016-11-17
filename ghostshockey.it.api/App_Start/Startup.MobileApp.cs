using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Owin;
using Swashbuckle.Application;
using Swashbuckle.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

using ghostshockey.it.api.Models;
using Microsoft.OData.Edm;
using ghostshockey.it.api.Controllers;

namespace ghostshockey.it.api
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();
            //config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //   name: "DefaultApi",
            //   routeTemplate: "api/{controller}/{id}",
            //   defaults: new { id = RouteParameter.Optional }
            //);

            config
              .EnableSwagger(c =>
              {
                  c.SingleApiVersion("v1", "Ghostshockey API");
                  c.CustomProvider(defaultProvider => new ODataSwaggerProvider(defaultProvider, c, config));
              })
              .EnableSwaggerUi();

            //new MobileAppConfiguration()
            //    .UseDefaultConfiguration()
            //    .ApplyTo(config);

            //// Use Entity Framework Code First to create database tables based on your DbContext
            ////Database.SetInitializer(new api_ghostsInitializer());

            //// To prevent Entity Framework from modifying your database schema, use a null database initializer
            //// Database.SetInitializer<api_ghostsContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }

            config.MapODataServiceRoute("ODataRoute", "odata", GetEdmModel());

            config.EnableCors();

            config.EnsureInitialized();

            app.UseWebApi(config);
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "Ghostshockey";
            builder.ContainerName = "GhostshockeyContainer";

            builder.EntitySet<Year>("Years");
            builder.EntitySet<Category>("Categories");
            builder.EntitySet<Club>("Clubs");
            builder.EntitySet<Team>("Teams");
            builder.EntitySet<Tournament>("Tournaments");
            builder.EntitySet<Match>("Matches");
            //builder.EntitySet<VinylRecord>("VinylRecords");

            var loginAction = builder.Action("login");
            loginAction.Parameter<string>("username");
            loginAction.Parameter<string>("password");
            loginAction.Returns<string>();
            //loginAction.Namespace = "Ghostshockey.Actions";

            return builder.GetEdmModel();
        }

    }

  

    //public class api_ghostsInitializer : CreateDatabaseIfNotExists<api_ghostsContext>
    //{
    //    protected override void Seed(api_ghostsContext context)
    //    {
    //        List<TodoItem> todoItems = new List<TodoItem>
    //        {
    //            new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
    //            new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
    //        };

    //        foreach (TodoItem todoItem in todoItems)
    //        {
    //            context.Set<TodoItem>().Add(todoItem);
    //        }

    //        base.Seed(context);
    //    }
    //}
}

