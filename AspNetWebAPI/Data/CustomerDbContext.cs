using AspNetWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebAPI.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
