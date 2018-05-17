using BreadShop.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Application.Dtos.Stock
{
    /// <summary>
    /// Represents the defiition of a stockdto entity
    /// </summary>
    public class StockDto
    {
        /// <summary>
        /// Get or set id of the stockdto
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// Get or set total quantity of the stockdto
        /// </summary>
        public int TotalQuantity { get; set; }

        /// <summary>
        /// Get or set total price of the stockdto
        /// </summary>
        public int TotalPrice { get; set; }

        /// <summary>
        /// Get or set created date and time of the stockdto
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Get or set updated date and time of the stockdto.
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public IList<ProductDto> Products { get; set; }
    }
}
