using Microsoft.EntityFrameworkCore;

namespace Example.DataRepository
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Customer> Customer { get; set; }
    }
}
