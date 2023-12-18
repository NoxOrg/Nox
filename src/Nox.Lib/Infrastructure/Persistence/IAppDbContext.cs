using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nox.Domain;

namespace Nox.Infrastructure.Persistence
{
    /// <summary>
    /// Marker interface to identify the application's DbContext.
    /// </summary>
    public interface IAppDbContext 
    {
        EntityEntry Remove(object entity);

        DbSet<T> Set<T>() where T : class;

        ValueTask<T> AddEntityAsync<T>(T entity, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IEntity;

        EntityEntry Update(object entity);

        /// <summary>
        /// Gets and Consumes a Sequence Next Value
        /// </summary>
        public Task<long> GetSequenceNextValueAsync(string sequenceName);        
    }
}
