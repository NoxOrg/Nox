﻿
using System.Linq.Expressions;

namespace Nox.Domain;

public interface IRepository
{
    IQueryable<T> Query<T>(params Expression<Func<T, object>>[] includeExpressions) where T : class, IEntity;
    
    ValueTask<T?> FindAsync<T>(params object?[]? keyValues) where T : class, IEntity;
    ValueTask<T?> FindAsync<T>(object?[]? keyValues, CancellationToken cancellationToken) where T : class, IEntity;
    
    ValueTask<T?> FindAndIncludeAsync<T>(object?[]? keyValues, Expression<Func<T, IEnumerable<object>>> includeExpression, CancellationToken cancellationToken) where T : class, IEntity;
    ValueTask<T?> FindAndIncludeAsync<T>(object?[]? keyValues, Expression<Func<T, object?>> includeExpression, CancellationToken cancellationToken) where T : class, IEntity;

    ValueTask<T> AddAsync<T>(T entity, CancellationToken cancellationToken = default(CancellationToken)) where T : class, IEntity;

    void Update<T>(T entity) where T : IEntity;

    /// <summary>
    /// Deletes Entity
    /// </summary>
    void Delete<T>(T entity) where T : IEntity;

    /// <summary>
    /// Deletes Multiple Entities
    /// </summary>
    void DeleteRange<T>(IEnumerable<T> entities) where T : IEntity;

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

    Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    void SetStateModified(object entity);
    void SetStateDetached(object entity);    
}
