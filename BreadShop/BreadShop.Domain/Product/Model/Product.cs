using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Domain.Products.Model
{
    /// <summary>
    /// Represents the defination of a product entity
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Get or set id of the product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Get or set product name of the product 
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Get or set ingrediants of the product
        /// </summary>
        public string Ingrediants { get; set; }

        /// <summary>
        /// Get or set descriptions of the product
        /// </summary>
        public string Descriptions { get; set; }

        /// <summary>
        /// Get or set Quantity of the product
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Get or set created date and time of the product
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Get or set updated date and time of the product
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Get or set stock id
        /// </summary>
        public Stock.Model.Stock Stock { get; set; }
    }
}
