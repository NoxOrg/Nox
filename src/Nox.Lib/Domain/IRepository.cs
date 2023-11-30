
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
}
