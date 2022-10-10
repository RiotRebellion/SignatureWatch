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

        }
    }
}
