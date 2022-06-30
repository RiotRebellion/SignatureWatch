using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureWatch.Domain.Entities;
using SignatureWatch.Infrastructure.Persistence.Configurations.Base;

namespace SignatureWatch.Infrastructure.Persistence.Configurations
{
    internal class EmployeeConfiguration : EntityConfiguration<Employee>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<Employee> builder)
        {
        }
    }
}
