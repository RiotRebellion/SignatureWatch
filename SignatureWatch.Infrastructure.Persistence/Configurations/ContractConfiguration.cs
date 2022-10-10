using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureWatch.Domain.Entities;
using SignatureWatch.Infrastructure.Persistence.Configurations.Base;

namespace SignatureWatch.Infrastructure.Persistence.Configurations
{
    internal class ContractConfiguration : EntityConfiguration<Contract>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<Contract> builder)
        {
            builder.HasMany(p => p.SoftwareLicenses)
                .WithOne(p => p.Contract)
                .HasForeignKey(p => p.ContractGuid)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
