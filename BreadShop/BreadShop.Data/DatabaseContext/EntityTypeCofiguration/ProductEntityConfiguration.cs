using BreadShop.Domain.Products.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Data.DatabaseContext.EntityTypeCofiguration
{
    internal class ProductEntityConfiguration : EntityTypeConfiguration<Product>
    {
        public override void Map(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(product => product.ProductId);
        }
    }
}
