using BreadShop.Application.Dtos.Product;
using BreadShop.Application.Services.Product;
using BreadShop.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using BreadShop.Domain.Products.Model;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace BreadShop.Application.Tests
{
    /// <summary>
    /// testing product application service.
    /// </summary>
    public class ProductsApplicationServiceTest
    {
        /// <summary>
        /// testing save product.
        /// </summary>
        [Fact]
        public void TestSaveProduct()
        {
            //Arrange
            Mock<IProductRepository> mockProductRepository =
                new Mock<IProductRepository>();
            ProductDto product =
                new ProductDto()
                {
                    ProductName = "Product1",
                    Ingrediants = "ingrediants",
                    Descriptions = "Descriptions",
                    Quantity = 500
                };
            IProductApplicationService productsApplicationService =
                new ProductApplicationService(mockProductRepository.Object);

            //Act
            Product result = productsApplicationService.SaveProduct(product);

            //Assert
            Assert.IsType<Product>(result);
        }

        /// <summary>
        /// testing save product with null object.
        /// </summary>
        [Fact]
        public void NullTestSaveProduct()
        {
            //Arrange
            Mock<IProductRepository> mockProductRepository =
                new Mock<IProductRepository>();
            ProductDto product = null;
            IProductApplicationService productsApplicationService =
                new ProductApplicationService(mockProductRepository.Object);

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => productsApplicationService
                .SaveProduct(product));
        }

        /// <summary>
        /// testing get products method.
        /// </summary>
        [Fact]
        public void GetProducts()
        {
            //Arrange
            Mock<IProductRepository> mockProductRepository =
                new Mock<IProductRepository>();

            mockProductRepository.Setup(service => service.GetProducts())
                .Returns(new List<Product>() { new Product(), new Product() });
            IProductApplicationService productsApplicationService = new ProductApplicationService(mockProductRepository.Object);
            //Act
           IList<ProductDto> result = productsApplicationService.GetProducts();

            //Assert
            Assert.IsAssignableFrom<IList<ProductDto>>(result);
        }

        /// <summary>
        /// testing getproductbyid method.
        /// </summary>
        [Fact]
        public void TestGetProductById()
        {
            //Arrange
            int id = 1;
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(service => service.GetProductById(id))
                .Returns( new Product()
                {
                    ProductId = 1,
                    Ingrediants = "ingrediants",
                    Descriptions = "descriptions",
                    Quantity = 500,
                });
            IProductApplicationService productsApplicationService = new ProductApplicationService(mockProductRepository.Object);

            //Act
            ProductDto result = productsApplicationService.GetProductById(id);

            //Assert
            Assert.IsType<ProductDto>(result);
        }

        /// <summary>
        /// testing getproductbyid method with null object.
        /// </summary>
        [Fact]
        public void TestGetProductByIdNull()
        {
            //Arrange
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            IProductApplicationService productsApplicationService = new ProductApplicationService(mockProductRepository.Object);
            int id = 0;

            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => productsApplicationService
                .GetProductById(id));
        }

        /// <summary>
        /// products list.
        /// </summary>
        private static List<object[]> products = new List<object[]>
        {
            new object[]
            {
                0,
                "ingrediants",
                "descriptions",
                 500,
            },

            new object[]
            {
                -1,
                "ingrediants",
                "descriptions",
                500,
            },

            new object[]
            {
                1,
                "",
                "descriptions",
                500,
            },

            new object[]
            {
                1,
                "ingrediants",
                "",
                500,
            },

            new object[]
            {
                1,
                "ingrediants",
                "ingrediants",
                0,
            },

            new object[]
            {
                0,
                "",
                "",
                0,
            },
        };

        /// <summary>
        /// returning testdata
        /// </summary>
        public static IEnumerable<object[]> TestData
        {
            get { return products; }
        }

        /// <summary>
        /// testing UpdateProduct method with null object.
        /// </summary>
        /// <param name="productId">product id</param>
        /// <param name="ingrediants">product ingrediants</param>
        /// <param name="descriptions">product descriptions</param>
        /// <param name="quantity">product quantity</param>
        [Theory]
        [MemberData(nameof(TestData))]
        public void TestUpdateProductVariableNull(int productId, string ingrediants, string descriptions,
            int quantity)
        {
            //Arrange
            Mock<IProductRepository> mockProductRepository =
                new Mock<IProductRepository>();
            IProductApplicationService productsApplicationService =
                new ProductApplicationService(mockProductRepository.Object);

            ProductDto products = new ProductDto()
            {
                ProductId = productId,
                Ingrediants = ingrediants,
                Descriptions = descriptions,
                Quantity = quantity
            };

            //Act & Assert
            Assert.Throws<InvalidOperationException>(() => productsApplicationService
                .UpdateProduct(products));
        }
    }
}

