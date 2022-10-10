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
            builder.HasMany(p => p.AccordanceSertificates)
                .WithOne(p => p.Formular)
                .HasForeignKey(p => p.FormularGuid)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
