using System;
using System.Collections.Generic;
using System.Text;
using BreadShop.Domain.Stock.Model;
using BreadShop.Application.Dtos.Stock;
using BreadShop.Application.Dtos.Product;

namespace BreadShop.Application.Mappers.Product
{
    /// <summary>
    /// mapping the stock object.
    /// </summary>
    public class StockMapper : IModelMapper<StockDto, Stock>
    {
        /// <summary>
        /// mapping stock dto to stock object
        /// </summary>
        /// <param name="stock">stock dto object</param>
        /// <returns>stock type object</returns>
        public IList<Domain.Products.Model.Product> ProductDtoFrom(StockDto stock)
        {
            IList<Domain.Products.Model.Product> productList = new List<Domain.Products.Model.Product>();

            Stock newStock = new Stock()
            {
                StockId = stock.StockId
            };

            foreach (ProductDto selectedProducts in stock.Products)
            {
                productList.Add(new Domain.Products.Model.Product()
                {
                    ProductId = selectedProducts.ProductId,
                    ProductName = selectedProducts.ProductName,
                    Ingrediants = selectedProducts.Ingrediants,
                    Descriptions = selectedProducts.Descriptions,
                    Quantity = selectedProducts.Quantity,
                    CreatedOn = selectedProducts.CreatedOn,
                    UpdatedOn = selectedProducts.UpdatedOn
                });
            }

            return productList;
        }

        /// <summary>
        /// mapping stock object to stockdto object
        /// </summary>
        /// <param name="domainEntity">stock type object</param>
        /// <returns>stockdto object</returns>
        public StockDto DtoFrom(Stock domainEntity)
        {
            return new StockDto()
            {
                StockId = domainEntity.StockId,
                TotalQuantity = domainEntity.TotalQuantity,
                TotalPrice = domainEntity.TotalPrice,
                CreatedOn = domainEntity.CreatedOn,
                UpdatedOn = domainEntity.UpdatedOn
            };
        }

        /// <summary>
        /// mapping stock dto to stock object
        /// </summary>
        /// <param name="dto">stockdto type object</param>
        /// <returns>stock type object</returns>
        public Stock EntityFrom(StockDto dto)
        {
            return new Stock()
            {
                StockId = dto.StockId,
                TotalQuantity = dto.TotalQuantity,
                TotalPrice = dto.TotalPrice,
                CreatedOn = dto.CreatedOn,
                UpdatedOn = dto.UpdatedOn
            };
        }
    }
}
