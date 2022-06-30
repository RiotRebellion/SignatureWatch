using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureWatch.Domain.Entities;
using SignatureWatch.Infrastructure.Persistence.Configurations.Base;

namespace SignatureWatch.Infrastructure.Persistence.Configurations
{
    internal class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Username).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.Email).IsRequired();
        }
    }
}
