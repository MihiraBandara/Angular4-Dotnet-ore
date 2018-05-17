using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using BreadShop.Application.Dtos.Stock;
using BreadShop.Application.Services.Stock;
using BreadShop.WebApi.Controllers;
using Xunit;

namespace BreadShop.WebApi.Tests
{
    public class StocksControllerTest
    {
        [Fact]
        public void TestPut()
        {
            //Arrange
            Mock<IStockApplicationService> mockStockApplicationService =
                new Mock<IStockApplicationService>();
            StockDto stock =
                new StockDto()
                {
                    TotalPrice = 5000,
                    TotalQuantity = 500,
                };
            StocksController stocksController =
                new StocksController(mockStockApplicationService.Object);

            //Act
            IActionResult actionResult = stocksController.Post(stock);

            //Assert
            Assert.IsType<CreatedResult>(actionResult);
        }

        [Fact]
        public void NullTestPut()
        {
            //Arrange
            Mock<IStockApplicationService> mockStockApplicationService =
                new Mock<IStockApplicationService>();
            StockDto stock = null;
            StocksController stocksController = new StocksController(mockStockApplicationService.Object);

            //Act
            IActionResult actionResult = stocksController.Post(stock);

            //Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
        }
    }
}
