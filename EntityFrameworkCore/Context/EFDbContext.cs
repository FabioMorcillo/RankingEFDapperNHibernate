using Microsoft.EntityFrameworkCore;

using Models;

namespace EntityFrameworkCoreFramework.Context
{
    public class EFDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF5;Integrated Security=True");
    }
}
