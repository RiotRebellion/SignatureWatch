using Microsoft.EntityFrameworkCore;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Gateways;

namespace SignatureWatch.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        DbSet<AccordanceSertificate> AccordanceSertificates { get; set; }

        DbSet<Contract> Contracts { get; set; }

        DbSet<Distribution> Distributions { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<Formular> Formulars { get; set; }

        DbSet<Signature> Signatures { get; set; }

        DbSet<Software> Softwares { get; set; }

        DbSet<SoftwareLicense> SoftwareLicenses { get; set; }

        DbSet<SoftwareType> SoftwareTypes { get; set; }

        DbSet<Support> Supports { get; set; }

        DbSet<User> Users { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
