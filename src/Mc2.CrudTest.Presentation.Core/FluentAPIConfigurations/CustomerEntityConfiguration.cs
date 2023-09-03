using Mc2.CrudTest.Presentation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Mc2.CrudTest.Presentation.Core.FluentAPIConfigurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(e => new { e.FirstName, e.LastName, e.DateOfBirth }).IsUnique();
            builder.HasIndex(e => new { e.Email }).IsUnique();
            builder.Property(p => p.FirstName)
                    .HasMaxLength(100).IsRequired(true);
            builder.Property(p => p.LastName)
                   .HasMaxLength(150).IsRequired(true);
            builder.Property(p => p.DateOfBirth)
             .HasColumnType("Date");
            builder.Property(p => p.PhoneNumber)
                        .HasColumnType("VARCHAR").HasMaxLength(20);
            builder.Property(p => p.Email)
                   .HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.BankAccountNumber)
                       .HasMaxLength(25);
            

        }
    }
}
