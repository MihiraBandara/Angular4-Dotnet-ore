using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// Definition representing entity type configuration.
    /// </summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    internal abstract class EntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }

    /// <summary>
    /// Defines extention method AddConfiguration to ModelBuilder.
    /// </summary>
    internal static class ModelBuilderExtensions
    {
        /// <summary>
        /// Adds entity configuration to model builder.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="modelBuilder">ModelBuilder instance</param>
        /// <param name="configuration">Instance of EntityTypeConfiguration.</param>
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration)
            where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
    }
}
