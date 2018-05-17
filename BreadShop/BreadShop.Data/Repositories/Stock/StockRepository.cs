using System;
using System.Collections.Generic;
using System.Text;
using BreadShop.Domain.Repositories;
using BreadShop.Data.DatabaseContext;
using BreadShop.Domain.Products.Model;
using BreadShop.Domain.Stock.Model;

namespace BreadShop.Data.Repositories.Stock
{
    /// <summary>
    /// implementation of stock repository data access.
    /// </summary>
    public class StockRepository:IStockRepository
    {
        private readonly BreadShopDatabaseContext _breadShopDatabaseContext;

        public StockRepository(BreadShopDatabaseContext breadShopDatabaseContext)
        {
            this._breadShopDatabaseContext = breadShopDatabaseContext;
        }

        /// <summary>
        /// saving stock object
        /// </summary>
        /// <param name="stock">stock object</param>
        /// <param name="products">product object</param>
        /// <returns>saved stock</returns>
        public Domain.Stock.Model.Stock SaveStock(Domain.Stock.Model.Stock stock, IList<Domain.Products.Model.Product> products)
        {
            foreach (Domain.Products.Model.Product product in products)
            {
                Domain.Products.Model.Product selectedProduct =
                    _breadShopDatabaseContext.Products.Find(product.ProductId);
                selectedProduct.Quantity = selectedProduct.Quantity + product.Quantity;
                selectedProduct.UpdatedOn= DateTime.Now;
            }
            _breadShopDatabaseContext.Stocks.Add(stock);
            _breadShopDatabaseContext.SaveChanges();
            return stock;
        }
    }
 
}
