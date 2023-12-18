using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Nox.Infrastructure.Persistence
{
    /// <summary>
    /// Marker interface to identify the application's DbContext.
    /// </summary>
    public interface IAppDbContext 
    {
        EntityEntry Remove(object entity);

        DbSet<T> Set<T>() where T : class;

        ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default(CancellationToken));

        EntityEntry Update(object entity);

        /// <summary>
        /// Gets and Consumes a Sequence Next Value
        /// </summary>
        public Task<long> GetSequenceNextValueAsync(string sequenceName);        
    }
}
