using System.Linq.Expressions;
using Nox.Extensions;
using Nox.Infrastructure.Persistence;

namespace Nox.Domain;

public sealed class Repository : IRepository
{
    private readonly IAppDbContext _dbContext;

    public Repository(IAppDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        _dbContext = dbContext;
    }

    #region IRepository

    public  IQueryable<T> Query<T>(Expression<Func<T, bool>> predicate) where T :class, IEntity
    {
        return _dbContext.Set<T>().Where(predicate: predicate);
    }

    public  IQueryable<T> QueryOwned<T>(Expression<Func<T, bool>> predicate) where T : class, IOwnedEntity
    {
        return _dbContext.Set<T>().Where(predicate: predicate);
    }

    public async Task AddAsync(object entity)
    {
        await _dbContext.AddAsync(entity);
    }

    public void Update(object entity)
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
