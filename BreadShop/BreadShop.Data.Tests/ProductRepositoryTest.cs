using BreadShop.Data.DatabaseContext;
using BreadShop.Data.Repositories.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BreadShop.Domain.Products.Model;
using Xunit;
using BreadShop.Domain.Repositories;

namespace BreadShop.Data.Tests
{
    public class ProductRepositoryTest
    {
        [Fact]
        public void SaveProductTest()
        {
            // Arrange
            DbContextOptions<BreadShopDatabaseContext> options =
                new DbContextOptionsBuilder<BreadShopDatabaseContext>()
                    .UseInMemoryDatabase(databaseName: "BreadShopSaveProductTestDatabase")
                    .Options;

            using (BreadShopDatabaseContext dbContext = new BreadShopDatabaseContext(options))
            {


                Product newProduct =
                    new Product()
                    {
                        ProductId = 1,
                        Ingrediants = "ingrediants",
                        Descriptions = "descriptions",
                        Quantity = 500,
                    };

                ProductRepository productRepository = new ProductRepository(dbContext);
                productRepository.SaveProduct(newProduct);
                int productsCount = dbContext.Set<Product>()
                    .Where(saveProduct =>
                        saveProduct.ProductId == newProduct.ProductId).Count();

                //Assert
                Assert.Equal(1, productsCount);
                dbContext.Dispose();
            }
        }


        [Fact]
        public void GetProductsTest()
        {
            // Arrange
            DbContextOptions<BreadShopDatabaseContext> options =
                new DbContextOptionsBuilder<BreadShopDatabaseContext>()
                    .UseInMemoryDatabase(databaseName: "BreadShopTestGetProductDatabase")
                    .Options;

            List<Product> result = new List<Product>();

            using (BreadShopDatabaseContext dbContext = new BreadShopDatabaseContext(options))
            {

                dbContext.Products.Add(new Product()
                {
                    ProductId = 1,
                    Ingrediants = "ingrediants",
                    Descriptions = "descriptions",
                    Quantity = 500,
                });
                dbContext.Products.Add(new Product()
                {
                    ProductId = 2,
                    Ingrediants = "ingrediants",
                    Descriptions = "descriptions",
                    Quantity = 500,
                });
                dbContext.SaveChanges();

                //Act
                IProductRepository productRepository = new ProductRepository(dbContext);
                result = productRepository.GetProducts().ToList();

                //Assert
                Assert.Equal(2, result.Count);
                dbContext.Dispose();
            }
        }


        [Fact]
        public void GetByIdTest()
        {
            // Arrange
            DbContextOptions<BreadShopDatabaseContext> options =
                new DbContextOptionsBuilder<BreadShopDatabaseContext>()
                    .UseInMemoryDatabase(databaseName: "BreadShopTestGetByIdDatabase")
                    .Options;

            using (BreadShopDatabaseContext dbContext = new BreadShopDatabaseContext(options))
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

                ProductRepository productRepository = new ProductRepository(dbContext);
                Product result = productRepository.GetProductById(1);


                //Assert
                Assert.Equal(500, result.Quantity);
                dbContext.Dispose();
            }
        }

        [Fact]
        public void GetByIdTestNull()
        {
            // Arrange
            DbContextOptions<BreadShopDatabaseContext> options =
                new DbContextOptionsBuilder<BreadShopDatabaseContext>()
                    .UseInMemoryDatabase(databaseName: "BreadShopTestGetByIdDatabase")
                    .Options;

            using (BreadShopDatabaseContext dbContext =
                new BreadShopDatabaseContext(options))
            {

                ProductRepository productRepository = new ProductRepository(dbContext);

                //Act & Assert
                Assert.Throws<InvalidOperationException>(() => productRepository
                    .GetProductById(1));
            }
        }


        [Fact]
        public void UpdateProductTestNotFound()
        {
            // Arrange
            DbContextOptions<BreadShopDatabaseContext> options =
                new DbContextOptionsBuilder<BreadShopDatabaseContext>()
                    .UseInMemoryDatabase(databaseName: "BreadShopTestUpdateProductDatabase")
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

                Product newProduct =
                    new Product()
                    {
                        ProductId = 2,
                        Ingrediants = "ingrediants1",
                        Descriptions = "descriptions1",
                        Quantity = 501,
                    };

                ProductRepository productRepository = new ProductRepository(dbContext);

                //Act & Assert
                Assert.Throws<InvalidOperationException>(() => productRepository
                    .UpdateProduct(newProduct));
            }
        }

        [Fact]
        public void UpdateProductTestNullId()
        {
            // Arrange
            DbContextOptions<BreadShopDatabaseContext> options =
                new DbContextOptionsBuilder<BreadShopDatabaseContext>()
                    .UseInMemoryDatabase(databaseName: "BreadShopTestUpdateProductDatabaseNullId")
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

                Product newProduct =
                    new Product()
                    {
                        ProductId = 0,
                        Ingrediants = "ingrediants1",
                        Descriptions = "descriptions1",
                        Quantity = 501,
                    };

                ProductRepository productRepository = new ProductRepository(dbContext);

                //Act & Assert
                Assert.Throws<InvalidOperationException>(() => productRepository
                    .UpdateProduct(newProduct));
            }
        }

    }
}
