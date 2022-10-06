using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureWatch.Domain.Entities;
using SignatureWatch.Infrastructure.Persistence.Configurations.Base;

namespace SignatureWatch.Infrastructure.Persistence.Configurations
{
    internal class FormularConfiguration : EntityConfiguration<Formular>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<Formular> builder)
        {
            builder.HasOne(p => p.Distribution)
                .WithOne(p => p.Formular)
                .HasForeignKey<Distribution>(p => p.FormularGuid)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
