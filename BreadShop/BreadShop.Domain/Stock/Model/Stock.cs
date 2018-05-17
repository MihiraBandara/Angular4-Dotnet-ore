using System;
using System.Collections.Generic;
using System.Text;
using BreadShop.Domain.Products.Model;

namespace BreadShop.Domain.Stock.Model
{
    /// <summary>
    /// Represents the defiition of a stock entity
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// Get or set id of the stock
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// Get or set total quantity of the stock
        /// </summary>
        public int TotalQuantity { get; set; }

        /// <summary>
        /// Get or set total price of the stock
        /// </summary>
        public int TotalPrice { get; set; }

        /// <summary>
        /// Get or set created date and time of the stock
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Get or set updated date and time of the stock.
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public IList<Product> Products { get; set; }
    }
}
