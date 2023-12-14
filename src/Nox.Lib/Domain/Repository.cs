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

    public async Task<IQueryable<T>> Query<T>(Expression<Func<T, bool>> predicate) where T : IEntity
    {
        _dbContext.
    }

    public async Task<IQueryable<T>> QueryOwned<T>(Expression<Func<T, bool>> predicate) where T : IOwnedEntity
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync<T>(T entity) where T : class
    {
        throw new NotImplementedException();
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
