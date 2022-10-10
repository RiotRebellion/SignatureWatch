using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureWatch.Domain.Entities;
using SignatureWatch.Infrastructure.Persistence.Configurations.Base;

namespace SignatureWatch.Infrastructure.Persistence.Configurations
{
    internal class SoftwareConfiguration : EntityConfiguration<Software>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<Software> builder)
        {
            builder.HasOne(p => p.Distribution)
                .WithOne(p => p.Software)
                .HasForeignKey<Distribution>(p => p.SoftwareGuid)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.SoftwareLicenses)
                .WithOne(p => p.Software)
                .HasForeignKey(p => p.SoftwareGuid)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
