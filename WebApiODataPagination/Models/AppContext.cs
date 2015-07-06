using System.Data.Entity;

namespace WebApiODataPagination.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
