using BreadShop.Domain.OrderItem.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Data.DatabaseContext.EntityTypeCofiguration
{
    internal class OrderItemEntityConfiguration : EntityTypeConfiguration<OrderItem>
    {
        public override void Map(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(orderItem => orderItem.OrderItemId);
        }
    }
}
