using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiSimplePagination.Models;

namespace WebApiSimplePagination.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly AppContext context = new AppContext();

        [ResponseType(typeof(CustomPaginateResult<Customer>))]
        public IHttpActionResult GetCustomers(int page, int rows)
        {
            var totalRows = context.Customers.Count();
            var totalPages = (int) Math.Ceiling((double) totalRows/rows);
            var results = context.Customers
                .OrderBy(c => c.Id)
                .Skip((page)*rows)
                .Take(rows)
                .ToList();

            var result = new CustomPaginateResult<Customer>()
            {
                PageSize = rows,
                TotalRows = totalRows,
                TotalPages = totalPages,
                CurrentPage = page,
                Results = results
            };

            return Ok(result);
        }
    }
}
