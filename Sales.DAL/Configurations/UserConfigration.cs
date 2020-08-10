using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.DAL.Configurations
{
    public class UserConfigration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder
             .Property(m => m.Username)
             .IsRequired()
             .HasMaxLength(50);
            builder
                  .Property(m => m.LastName)
                 .IsRequired()
                 .HasMaxLength(50);
            builder
                .ToTable("Users");
        }
    }
}
