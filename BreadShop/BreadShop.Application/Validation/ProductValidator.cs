using System;
using System.Collections.Generic;
using System.Text;
using BreadShop.Application.Dtos.Product;

namespace BreadShop.Application.Validation
{
    /// <summary>
    /// implementation of  product validator
    /// </summary>
    public class ProductValidator
    {
        /// <summary>
        /// validating product object.
        /// </summary>
        /// <param name="product">product object</param>
        /// <returns>isValid</returns>
        public bool IsPutValid(ProductDto product)
        {
            bool isValid = true;

            if (product.ProductId <= 0)
            {
                isValid = false;
            }

            if (product.Quantity <= 0 || product.Quantity == 0)
            {
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(product.ProductName) ||
                string.IsNullOrWhiteSpace(product.Descriptions) ||
                string.IsNullOrWhiteSpace(product.Ingrediants))
            {
                isValid = false;
            }

            return isValid;
        }

        public bool IsPostValid(ProductDto product)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(product.ProductName) ||
                string.IsNullOrWhiteSpace(product.Descriptions) ||
                string.IsNullOrWhiteSpace(product.Ingrediants))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
