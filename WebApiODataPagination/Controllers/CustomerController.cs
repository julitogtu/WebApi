using System.Linq;
using System.Web.Http;
using System.Web.OData;
using WebApiODataPagination.Models;

namespace WebApiODataPagination.Controllers
{
    
    public class CustomerController : ODataController
    {
        private readonly AppContext context = new AppContext();

        [EnableQuery]
        public IQueryable<Customer> GetCustomer()
        {
            return context.Customers;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
