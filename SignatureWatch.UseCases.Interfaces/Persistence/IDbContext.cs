using Microsoft.EntityFrameworkCore;

namespace SignatureWatch.UseCases.Interfaces.Persistence
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
