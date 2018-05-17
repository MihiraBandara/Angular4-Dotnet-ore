using BreadShop.Data.DatabaseContext;
using BreadShop.Domain.Stock.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BreadShop.Data.Repositories.Stock;
using BreadShop.Domain.Products.Model;
using Xunit;

namespace BreadShop.Data.Tests
{
    public class StockRepositoryTest
    {
        [Fact]
        public void SaveStockTest()
        {
            // Arrange
            DbContextOptions<BreadShopDatabaseContext> options =
                new DbContextOptionsBuilder<BreadShopDatabaseContext>()
                    .UseInMemoryDatabase(databaseName: "BreadShopTestDatabase")
                    .Options;

            using (BreadShopDatabaseContext dbContext =
                new BreadShopDatabaseContext(options))
            {
                dbContext.Products.Add(
                    new Product()
                    {
                        ProductId = 1,
                        Ingrediants = "ingrediants",
                        Descriptions = "descriptions",
                        Quantity = 500,
                    });

                dbContext.SaveChanges();
                IList<Product> newProduct = new List<Product>() { 
                    new Product()
                    {
                        ProductId = 1,
                        Ingrediants = "ingrediants",
                        Descriptions = "descriptions",
                        Quantity = 500,
                    }
                 };

                Stock stock =
                    new Stock()
                    {
                        TotalPrice = 5000,
                        TotalQuantity = 500,
                    };

                StockRepository stockRepository = new StockRepository(dbContext);
                stockRepository.SaveStock(stock, newProduct);
                int productsCount = dbContext.Set<Stock>()
                    .Where(saveProduct =>
                        stock.StockId == stock.StockId).Count();

                //Assert
                Assert.Equal(1, productsCount);
                dbContext.Dispose();
            }
        }
    }
}
