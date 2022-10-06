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
            builder.HasOne(p => p.SoftwareType)
                .WithMany(p => p.Softwares)
                .HasForeignKey(p => p.SoftwareTypeGuid)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
