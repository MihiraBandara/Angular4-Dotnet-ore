using BreadShop.Application.Dtos.Stock;
using BreadShop.Application.Services.Stock;
using BreadShop.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using BreadShop.Application.Dtos.Product;
using BreadShop.Domain.Stock.Model;
using Xunit;

namespace BreadShop.Application.Tests
{
    /// <summary>
    /// testing stock application service
    /// </summary>
    public class StockApplicationServiceTest
    {
        /// <summary>
        /// testing SaveStock method.
        /// </summary>
        [Fact]
        public void TestSaveStock()
        {
            //Arrange
            Mock<IStockRepository> mockStockRepository =
                new Mock<IStockRepository>();
            IList<ProductDto> products = new List<ProductDto>()
            {
                new ProductDto()
                {
                    ProductName = "Product1",
                    Ingrediants = "ingrediants",
                    Descriptions = "Descriptions",
                    Quantity = 500
                }
            };
            StockDto stock =
                new StockDto()
                {
                    TotalPrice = 5000,
                    TotalQuantity = 500,
                    Products = products
                };
            IStockApplicationService stocksApplicationService =
                new StockApplicationService(mockStockRepository.Object);

            //Act
            Stock result = stocksApplicationService.SaveStock(stock);

            //Assert
            Assert.IsType<Stock>(result);
        }

        /// <summary>
        /// testing SaveStock method with null object.
        /// </summary>
        [Fact]
        public void NullTestPut()
        {
            //Arrange
            Mock<IStockRepository> mockStockRepository =
                new Mock<IStockRepository>();
            StockDto stock = null;
            IStockApplicationService stocksApplicationService = new StockApplicationService(mockStockRepository.Object);

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => stocksApplicationService
                .SaveStock(stock));
        }
    }
}
