using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureWatch.Domain.Entities;
using SignatureWatch.Infrastructure.Persistence.Configurations.Base;

namespace SignatureWatch.Infrastructure.Persistence.Configurations
{
    internal class SoftwareLicenceConfiguration : EntityConfiguration<SoftwareLicense>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<SoftwareLicense> builder)
        {
            builder.HasOne(p => p.Software)
                .WithMany(p => p.SoftwareLicenses)
                .HasForeignKey(p => p.SoftwareGuid)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Support)
                .WithMany(p => p.SoftwareLicenses)
                .HasForeignKey(p => p.SupportGuid)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Contract)
                .WithMany(p => p.SoftwareLicenses)
                .HasForeignKey(p => p.ContractGuid)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
