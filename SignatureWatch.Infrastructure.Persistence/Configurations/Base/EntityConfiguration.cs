using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureWatch.Domain.Entities.Base;

namespace SignatureWatch.Infrastructure.Persistence.Configurations.Base
{
    internal abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            ConfigureOtherProperties(builder);
        }

        protected abstract void ConfigureOtherProperties(EntityTypeBuilder<TEntity> builder);
    }
}
