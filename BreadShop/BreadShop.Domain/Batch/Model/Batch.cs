using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Domain.Batch.Model
{
    /// <summary>
    /// Represents the defination of a Batch Entity
    /// </summary>
    public class Batch
    {
        /// <summary>
        /// Get or set batch id
        /// </summary>
        public int BatchId { get; set; }

        /// <summary>
        /// Get or set batch product id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Get or set batch stock id
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// Get or set batch quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Get or set batch purchashing price
        /// </summary>
        public int PurchashingPrice { get; set; }

        /// <summary>
        /// Get or set batch selling price
        /// </summary>
        public int SellingPrice { get; set; }

        /// <summary>
        /// Get or set batch created date and time
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Get or set batch updated date and time
        /// </summary>
        public DateTime UpdatedOn { get; set; }
    }
}
