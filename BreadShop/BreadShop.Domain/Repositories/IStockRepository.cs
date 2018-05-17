using System;
using System.Collections.Generic;
using System.Text;
using BreadShop.Domain.Products.Model;

namespace BreadShop.Domain.Repositories
{
    /// <summary>
    /// controlling stock repository implementation.
    /// </summary>
    public interface IStockRepository
    {
        /// <summary>
        /// saving the stock object
        /// </summary>
        /// <param name="stock">stock object</param>
        /// <param name="products">product object</param>
        /// <returns>saved stock</returns>
        Stock.Model.Stock SaveStock(Stock.Model.Stock stock, IList<Product>products);
    }
}
