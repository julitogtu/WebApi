using System.Data.Entity;

namespace WebApiSimplePagination.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
