using Nox.Abstractions;

namespace Nox.Factories
{
    /// <summary>
    /// Create entities using a dto 
    /// </summary>
    public interface IEntityFactory<T, E> where T : class where E : IEntity
    {
        E CreateEntity(T dto);
    }
}
