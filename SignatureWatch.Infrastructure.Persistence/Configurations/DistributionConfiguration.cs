using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureWatch.Domain.Entities;
using SignatureWatch.Infrastructure.Persistence.Configurations.Base;

namespace SignatureWatch.Infrastructure.Persistence.Configurations
{
    internal class DistributionConfiguration : EntityConfiguration<Distribution>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<Distribution> builder)
        {
            builder.HasOne(p => p.Software)
                .WithOne(p => p.Distribution)
                .HasForeignKey<Software>(p => p.DistributionGuid)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
