using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ProMvcProject.Domain.Entities;

namespace ProMvcProject.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // This adds default data directly to your SQL table
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Professional Laptop", Description = "High performance", Price = 1200.00m, StockQuantity = 10 },
                new Product { Id = 2, Name = "Wireless Mouse", Description = "Ergonomic", Price = 25.50m, StockQuantity = 50 },
                new Product { Id = 3, Name = "Mechanical Keyboard", Description = "RGB Backlit", Price = 80.00m, StockQuantity = 20 }
            );
        }

    }
}
