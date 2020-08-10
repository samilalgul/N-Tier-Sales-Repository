using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.DAL.Configurations
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder
              .HasKey(s => s.Id);

            builder
                .Property(s => s.Id)
                .UseIdentityColumn();

            builder
                .Property(s => s.SoldProducts);


            builder
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

            builder
                .ToTable("Sales");
        }
    }
}
