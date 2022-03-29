using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
        {

        }

        public CustomerDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Direction> directions { get; set; }



    }
}
