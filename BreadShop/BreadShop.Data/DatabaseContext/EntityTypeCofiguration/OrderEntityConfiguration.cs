using BreadShop.Domain.Order.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Data.DatabaseContext.EntityTypeCofiguration
{
     internal class OrderEntityConfiguration : EntityTypeConfiguration<Order>
     {
         public override void Map(EntityTypeBuilder<Order> builder)
         {
                builder.ToTable("Orders");
                builder.HasKey(order => order.OrderId);
         }
     }
}
