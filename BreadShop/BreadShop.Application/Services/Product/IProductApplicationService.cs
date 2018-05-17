using BreadShop.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Application.Services.Product
{
    /// <summary>
    /// product application service interface that control product application service
    /// implementation.
    /// </summary>
    public interface IProductApplicationService
    {
        /// <summary>
        /// saving product object
        /// </summary>
        /// <param name="productDto">product object that want to save</param>
        /// <returns>saved product object</returns>
        Domain.Products.Model.Product SaveProduct(ProductDto productDto);

        /// <summary>
        /// get all product list.
        /// </summary>
        /// <returns>all product list</returns>
        IList<ProductDto> GetProducts();

        /// <summary>
        /// updating product object
        /// </summary>
        /// <param name="productDto">product object that want to update</param>
        void UpdateProduct(ProductDto productDto);

        /// <summary>
        /// get product list by id
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>product details</returns>
        ProductDto GetProductById(int id);
    }
}
