using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApiODataPagination.Models;

namespace WebApiODataPagination
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(config =>
            {
                ODataConfig.Register(config); 
                WebApiConfig.Register(config);
            });
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DatabaseInitializer();
        }

        private static void DatabaseInitializer()
        {
            Database.SetInitializer<AppContext>(new AppDbInitializer());
            var context = new AppContext();
            context.Database.Initialize(true);
        }
    }
}