using KssDocker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KssDocker.Products
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Description = "First Product",
                    Price = 69.1
                },
                new Product()
                {
                    Id = 2,
                    Description = "Second Product",
                    Price = 69.2
                },
                new Product()
                {
                    Id = 3,
                    Description = "Third Product",
                    Price = 69.3
                },
                new Product()
                {
                    Id = 4,
                    Description = "Fourth Product",
                    Price = 69.4
                });
        }
    }
}
