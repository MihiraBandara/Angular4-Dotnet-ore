using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Domain.Order.Model
{
    /// <summary>
    /// Represents the definition of a Order entity.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Get or set id of the order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Get or set total price of the order.
        /// </summary>
        public int TotalPrice { get; set; }

        /// <summary>
        /// Get or set total quantity of the order.
        /// </summary>
        public int TotalQuantity { get; set; }

        /// <summary>
        /// Get or set created date and time of the order.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Get or set updated date and time of the order.
        /// </summary>
        public DateTime UpdateddOn { get; set; }
    }
}
