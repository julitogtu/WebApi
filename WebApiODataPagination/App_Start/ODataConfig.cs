using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using WebApiODataPagination.Models;

namespace WebApiODataPagination
{
    public class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            // Web API OData
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("Customer");
            config.MapODataServiceRoute(
                routeName: "odata",
                routePrefix: "odata",
                model: builder.GetEdmModel()
            );
        }
    }
}
