using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiSimplePagination.Models;

namespace WebApiSimplePagination.Controllers
{
    public class CustomerController : ApiController
    {
        private AppContext context = new AppContext();

        [ResponseType(typeof(CustomPaginateResult<Customer>))]
        public IHttpActionResult GetCustomers(int page)
        {
            var totalRows = context.Customers.Count();
            var totalPages = (int) Math.Ceiling((double) totalRows/20);
            var results = context.Customers
                .OrderBy(c => c.Id)
                .Skip((page)*20)
                .Take(20)
                .ToList();

            var result = new CustomPaginateResult<Customer>()
            {
                PageSize = 20,
                TotalRows = totalRows,
                TotalPages = totalPages,
                CurrentPage = page,
                Results = results
            };


            return Ok(result);
        }
    }
}
