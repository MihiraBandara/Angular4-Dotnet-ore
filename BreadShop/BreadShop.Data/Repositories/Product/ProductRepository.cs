using BreadShop.Data.DatabaseContext;
using BreadShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BreadShop.Domain.Products.Model;

namespace BreadShop.Data.Repositories.Product
{
    /// <summary>
    /// implementation of product repository data access.
    /// </summary>
    public class ProductRepository:IProductRepository
    {
        private readonly BreadShopDatabaseContext _breadShopDatabaseContext;

        public ProductRepository(BreadShopDatabaseContext _breadShopDatabaseContext)
        {
            this._breadShopDatabaseContext = _breadShopDatabaseContext;
        }

        /// <summary>
        /// saving product object
        /// </summary>
        /// <param name="product">product object</param>
        /// <returns>saved product object</returns>
        public Domain.Products.Model.Product SaveProduct(Domain.Products.Model.Product product)
        {
            _breadShopDatabaseContext.Database.EnsureCreated();
            _breadShopDatabaseContext.Products.Add(product);
            _breadShopDatabaseContext.SaveChanges();
            return product;
        }

        /// <summary>
        /// get all product list.
        /// </summary>
        /// <returns>all product list</returns>
        public IList<Domain.Products.Model.Product> GetProducts()
        {
            IList<Domain.Products.Model.Product> products = _breadShopDatabaseContext.Products.ToList();
            return products;
        }

        /// <summary>
        /// updating product object.
        /// </summary>
        /// <param name="product">product object that want to update.</param>
        public void UpdateProduct(Domain.Products.Model.Product product)
        {
            Domain.Products.Model.Product selectedProduct =
                _breadShopDatabaseContext.Products.Find(product.ProductId);
            if (selectedProduct != null)
            {
                selectedProduct.ProductName = product.ProductName;
                selectedProduct.Descriptions = product.Descriptions;
                selectedProduct.Ingrediants = product.Ingrediants;
                selectedProduct.Quantity = product.Quantity;
                selectedProduct.UpdatedOn = DateTime.Now;
                _breadShopDatabaseContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// get product details by id
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>product details</returns>
        /// <returns>product details</returns>
        public Domain.Products.Model.Product GetProductById(int id)
        {
            Domain.Products.Model.Product product = _breadShopDatabaseContext.Products.Find(id);
            if (product == null)
            {
                throw new InvalidOperationException();
            }
            return product;
        }

    }
}
