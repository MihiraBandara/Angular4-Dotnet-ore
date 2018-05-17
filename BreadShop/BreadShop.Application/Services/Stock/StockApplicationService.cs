using BreadShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using BreadShop.Application.Dtos.Stock;
using BreadShop.Application.Mappers.Product;
using BreadShop.Application.Validation;

namespace BreadShop.Application.Services.Stock
{
    /// <summary>
    /// implements the stock application service.
    /// </summary>
    public class StockApplicationService:IStockApplicationService
    {
        private readonly IStockRepository _stockRepository;

        public StockApplicationService(IStockRepository stockRepository)
        {
            this._stockRepository = stockRepository;
        }

        /// <summary>
        /// saving the stock object.
        /// </summary>
        /// <param name="stockDto">stock object that want to save.</param>
        /// <returns>saved stock object</returns>
        public Domain.Stock.Model.Stock SaveStock(StockDto stockDto)
        {
            StockValidator validator = new StockValidator();
            bool isValid = validator.IsPostValid(stockDto);
            StockMapper modelMapper = new StockMapper();
            Domain.Stock.Model.Stock stockEntity = modelMapper.EntityFrom(stockDto);
            if (!isValid || stockEntity == null)
            {
                throw new NullReferenceException();
            }
            
            IList<Domain.Products.Model.Product> productEntities = modelMapper.ProductDtoFrom(stockDto);
            stockEntity.CreatedOn = DateTime.Now;
            Domain.Stock.Model.Stock result = this._stockRepository.SaveStock(stockEntity, productEntities);
            return stockEntity;
        }
       
    }
}
