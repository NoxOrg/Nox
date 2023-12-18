
using System.Linq.Expressions;

namespace Nox.Domain;

public interface IRepository
{
    // needs to work with IEntity, IOwnedEntity and localized entity
    IQueryable<T> Query<T>(Expression<Func<T, bool>> predicate) where T : class, IEntity;
    IQueryable<T> QueryOwned<T>(Expression<Func<T, bool>> predicate) where T : class, IOwnedEntity;

    Task AddAsync(object entity);
    void Update(object entity);

    /// <summary>
    /// Deletes Entity
    /// </summary>
    void Delete<T>(T entity) where T : IEntity;

    /// <summary>
    /// Deletes Owned Entity
    /// </summary>
    void DeleteOwned<T>(T entity) where T : IOwnedEntity;

    /// <summary>
    /// Deletes a range of Owned Entities
    /// </summary>
    void DeleteOwned<T>(IEnumerable<T> entities) where T : IOwnedEntity;

    /// <summary>
    /// Gets and Consumes a Sequence Next Value
    /// </summary>
    /// <param name="sequenceName"></param>
    /// <returns></returns>
    Task<long> GetSequenceNextValueAsync(string sequenceName);
}
