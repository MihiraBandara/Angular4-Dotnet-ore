using BreadShop.Domain.Stock.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Data.DatabaseContext.EntityTypeCofiguration
{
    internal class StockEntityConfiguration : EntityTypeConfiguration<Stock>
    {
        public override void Map(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks");
            builder.HasKey(stock => stock.StockId);
        }
    }
}
