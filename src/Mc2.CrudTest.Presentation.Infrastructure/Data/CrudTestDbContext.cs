using Mc2.CrudTest.Presentation.Core.Entities;
using Mc2.CrudTest.Presentation.Core.FluentAPIConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

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
            modelBuilder.Entity<Customer>()
                        .HasIndex(e => new { e.FirstName, e.LastName,e.DateOfBirth }).IsUnique();
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
        }
        //For check constraints Enabled by EFCore.CheckConstraints package:
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseAllCheckConstraints();
           // .UseValidationCheckConstraints();
        
    }
}
