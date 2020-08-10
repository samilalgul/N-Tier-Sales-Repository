using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.DAL.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(s => s.Id)
                .UseIdentityColumn();

            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Customers");
        }
    }
}
