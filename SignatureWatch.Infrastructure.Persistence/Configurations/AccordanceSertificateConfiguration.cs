using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureWatch.Domain.Entities;
using SignatureWatch.Infrastructure.Persistence.Configurations.Base;

namespace SignatureWatch.Infrastructure.Persistence.Configurations
{
    internal class AccordanceSertificateConfiguration : EntityConfiguration<AccordanceSertificate>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<AccordanceSertificate> builder)
        {
            builder.HasOne(p => p.Formular)
                .WithMany(p => p.AccordanceSertificates)
                .HasForeignKey(p => p.FormularGuid)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
