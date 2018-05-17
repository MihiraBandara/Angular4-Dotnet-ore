using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Domain.OrderItem.Model
{
    /// <summary>
    /// Represents the defination of a order item entity.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Get or set id of the order item.
        /// </summary>
        public int OrderItemId { get; set; }

        /// <summary>
        /// Get or set product id of the order item.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Get or set batch id of the order item
        /// </summary>
        public int BatchId { get; set; }

        /// <summary>
        /// Get or set order id of the order item
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Get or set total quantity of the order item
        /// </summary>
        public int TotalQuantity { get; set; }

        /// <summary>
        /// Get or set total price of the order item.
        /// </summary>
        public int TotalPrice { get; set; }

    }
}
