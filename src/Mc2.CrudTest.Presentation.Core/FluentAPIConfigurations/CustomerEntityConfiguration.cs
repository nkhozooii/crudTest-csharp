using Mc2.CrudTest.Presentation.Core.DefineAttributes;
using Mc2.CrudTest.Presentation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mc2.CrudTest.Presentation.Core.FluentAPIConfigurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //we can remove all anotation and move it to here(I only set email attribute here)
            //For Example:
            builder.Property(p => p.FirstName)
                    .HasMaxLength(100).IsRequired(true);
            builder.Property(p => p.LastName)
                   .HasMaxLength(150).IsRequired(true);
           
        }
    }
}
