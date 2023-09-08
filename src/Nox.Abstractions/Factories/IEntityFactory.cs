using Nox.Application.Dto;
using Nox.Domain;

namespace Nox.Factories
{
    /// <summary>
    /// Factory for Entities
    /// </summary>
    public interface IEntityFactory<T, E> where T : IEntityCreateDto<E> where E : IEntity
    {
        /// <summary>
        /// Create an entity from a createDto instance
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>
        E CreateEntity(T createDto);
    }
}
