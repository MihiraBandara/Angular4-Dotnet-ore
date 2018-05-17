using BreadShop.Application.Dtos.Product;
using BreadShop.Application.Services.Product;
using BreadShop.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace BreadShop.WebApi.Tests
{
    public class ProductsControllerTest
    {
        [Fact]
        public void TestPut()
        {
            //Arrange
            Mock<IProductApplicationService> mockProductApplicationService =
                new Mock<IProductApplicationService>();
            ProductDto product =
                new ProductDto()
                {
                    ProductName = "Product1",
                    Ingrediants = "ingrediants",
                    Descriptions = "Descriptions",
                    Quantity = 500
                };
            ProductsController ProductsController =
                new ProductsController(mockProductApplicationService.Object);

            //Act
            IActionResult actionResult = ProductsController.Post(product);

            //Assert
            Assert.IsType<CreatedResult>(actionResult);
        }

        [Fact]
        public void NullTestPut()
        {
            //Arrange
            Mock<IProductApplicationService> mockProductApplicationService =
                new Mock<IProductApplicationService>();
            ProductDto product = null;
            ProductsController projectcontroller = new ProductsController(mockProductApplicationService.Object);

            //Act
            IActionResult actionResult = projectcontroller.Put(product);

            //Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }

        [Fact]
        public void TestGetAll()
        {
            //Arrange
            Mock<IProductApplicationService> mockProductApplicationService =
                new Mock<IProductApplicationService>();

            mockProductApplicationService.Setup(service => service.GetProducts())
                .Returns(new List<ProductDto>() { new ProductDto(), new ProductDto() });
            ProductsController controller = new ProductsController(mockProductApplicationService.Object);
            //Act
            IActionResult actionResult = controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public void TestGetProductById()
        {
            //Arrange
            Mock<IProductApplicationService> mockProductApplicationService = new Mock<IProductApplicationService>();
            ProductsController productsController = new ProductsController(mockProductApplicationService.Object);
            int id = 1;

            //Act
            IActionResult result = productsController.GetById(id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TestGetProductByIdNull()
        {
            //Arrange
            Mock<IProductApplicationService> mockProductApplicationService = new Mock<IProductApplicationService>();
            ProductsController productsController = new ProductsController(mockProductApplicationService.Object);
            int id = 0;

            //Act
            IActionResult result = productsController.GetById(id);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

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
                0,
                "",
                "",
                0,
            },
        };

        public static IEnumerable<object[]> TestData
        {
            get { return products; }
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void TestApprovedProjectVariableNull(int productId, string ingrediants, string descriptions,
            int quantity)
        {
            //Arrange
            Mock<IProductApplicationService> mockProductApplicationService =
                new Mock<IProductApplicationService>();
            ProductsController productController =
                new ProductsController(mockProductApplicationService.Object);

            ProductDto products = new ProductDto()
            {
                ProductId = productId,
                Ingrediants = ingrediants,
                Descriptions = descriptions,
                Quantity = quantity
            };

            //Act
            IActionResult result = productController.Put(products);

            //Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
