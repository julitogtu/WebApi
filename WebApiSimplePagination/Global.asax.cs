using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApiSimplePagination.Models;

namespace WebApiSimplePagination
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes); 
           
            DatabaseInitializer();
        }

        private static void DatabaseInitializer()
        {
            Database.SetInitializer<AppContext>(null);
            AppContext context = new AppContext();
            context.Database.Initialize(true);
        }
    }
}