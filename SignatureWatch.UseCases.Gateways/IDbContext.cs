﻿using Microsoft.EntityFrameworkCore;

namespace SignatureWatch.UseCases.Gateways
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
