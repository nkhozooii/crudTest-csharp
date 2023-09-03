using Mc2.CrudTest.Presentation.Core.Entities;
using Mc2.CrudTest.Presentation.Core.FluentAPIConfigurations;
using Microsoft.EntityFrameworkCore;


namespace Mc2.CrudTest.Presentation.Core
{
    public class CrudTestDbContext : DbContext
    {
        public CrudTestDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers => Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration()); 
        }
    }
}
