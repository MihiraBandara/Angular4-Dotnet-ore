using BreadShop.Domain.Batch.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadShop.Data.DatabaseContext.EntityTypeCofiguration
{
    internal class BatchEntityConfiguration : EntityTypeConfiguration<Batch>
    {
        public override void Map(EntityTypeBuilder<Batch> builder)
        {
            builder.ToTable("Batches");
            builder.HasKey(batch => batch.BatchId);
        }
    }
}
