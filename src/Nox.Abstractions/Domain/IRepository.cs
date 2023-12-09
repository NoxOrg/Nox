
namespace Nox.Domain;

public interface IRepository
{
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
