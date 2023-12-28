using System.Linq.Expressions;
using Nox.Extensions;
using Nox.Infrastructure.Persistence;

namespace Nox.Domain;

public sealed class Repository : IRepository
{
    private readonly EntityDbContextBase _dbContext;

    public Repository(EntityDbContextBase dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        _dbContext = dbContext;
    }

    #region IRepository

    public  IQueryable<T> Query<T>(Expression<Func<T, bool>> predicate) where T :class, IEntity
    {
        return _dbContext.Set<T>().Where(predicate: predicate);
    }

    public async ValueTask<T> AddAsync<T>(T entity, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IEntity
    {
        var entry = await _dbContext.AddAsync(entity, cancellationToken);
        return entry.Entity;
    }

    public void Update<T>(T entity) where T : IEntity
    {
        _dbContext.Update(entity);
    }

    public void Delete<T>(T entity) where T : IEntity
    {
        _dbContext.Remove(entity);
    }
    public void DeleteOwned<T>(T entity) where T : IOwnedEntity
    {
        _dbContext.Remove(entity);
    }
    public void DeleteOwned<T>(IEnumerable<T> entities) where T : IOwnedEntity
    {
        ArgumentNullException.ThrowIfNull(entities);

        entities.ForEach(e => DeleteOwned(e));
    }

    public async Task<long> GetSequenceNextValueAsync(string sequenceName)
    {
       return await _dbContext.GetSequenceNextValueAsync(sequenceName);
    }
    #endregion
}
