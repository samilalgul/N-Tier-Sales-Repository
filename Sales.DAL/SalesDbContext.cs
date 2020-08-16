using Microsoft.EntityFrameworkCore;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.DAL
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public SalesDbContext(DbContextOptions<SalesDbContext> contextOptions) : base(contextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().ToTable("Sales");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}
