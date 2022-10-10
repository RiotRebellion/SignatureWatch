using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureWatch.Domain.Entities;
using SignatureWatch.Infrastructure.Persistence.Configurations.Base;

namespace SignatureWatch.Infrastructure.Persistence.Configurations
{
    internal class SupportConfiguration : EntityConfiguration<Support>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<Support> builder)
        {
            builder.HasMany(p => p.SoftwareLicenses)
                .WithOne(p => p.Support)
                .HasForeignKey(p => p.SupportGuid)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
