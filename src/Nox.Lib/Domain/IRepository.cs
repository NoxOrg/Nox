
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
    void DeleteOwnedRange<T>(IEnumerable<T> entities) where T : IOwnedEntity;
}
