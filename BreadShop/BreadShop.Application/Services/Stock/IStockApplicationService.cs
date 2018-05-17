using BreadShop.Application.Dtos.Stock;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Application.Services.Stock
{
    /// <summary>
    /// interface that control stock application service.
    /// </summary>
    public interface IStockApplicationService
    {
        /// <summary>
        /// saving the stock object 
        /// </summary>
        /// <param name="stock">stock object that want to save</param>
        /// <returns>saved stock object</returns>
        Domain.Stock.Model.Stock SaveStock(StockDto stock);

    }
}
