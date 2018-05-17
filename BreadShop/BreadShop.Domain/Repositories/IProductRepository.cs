using BreadShop.Domain.Products.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Domain.Repositories
{
    /// <summary>
    /// contolling the product repository implementation.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// saving the product object.
        /// </summary>
        /// <param name="product">product object that want to save</param>
        /// <returns>saved product</returns>
        Product SaveProduct(Product product);

        /// <summary>
        /// get all product list.
        /// </summary>
        /// <returns>product list</returns>
        IList<Domain.Products.Model.Product> GetProducts();

        /// <summary>
        /// updating the product object.
        /// </summary>
        /// <param name="product">product object that want to update.</param>
        void UpdateProduct(Domain.Products.Model.Product product);

        /// <summary>
        /// get product details by id
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>product details</returns>
        Product GetProductById(int id);
    }
}
