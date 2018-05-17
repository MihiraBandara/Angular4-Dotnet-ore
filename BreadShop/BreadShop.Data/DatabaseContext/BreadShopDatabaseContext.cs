using BreadShop.Data.DatabaseContext.EntityTypeCofiguration;
using BreadShop.Domain.Batch.Model;
using BreadShop.Domain.Order.Model;
using BreadShop.Domain.OrderItem.Model;
using BreadShop.Domain.Products.Model;
using BreadShop.Domain.Stock.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Data.DatabaseContext
{
    public class BreadShopDatabaseContext:DbContext
    {
        public BreadShopDatabaseContext(DbContextOptions<BreadShopDatabaseContext> options)
        : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Batch> Batches { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new BatchEntityConfiguration());
            modelBuilder.AddConfiguration(new OrderEntityConfiguration());
            modelBuilder.AddConfiguration(new OrderItemEntityConfiguration());
            modelBuilder.AddConfiguration(new ProductEntityConfiguration());
            modelBuilder.AddConfiguration(new StockEntityConfiguration());
        }
    }
}
