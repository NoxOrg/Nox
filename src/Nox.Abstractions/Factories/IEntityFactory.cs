using Nox.Application.Dto;
using Nox.Domain;

namespace Nox.Factories
{
    /// <summary>
    /// Factory for Entities
    /// </summary>
    public interface IEntityFactory<E,C> where E : IEntity where C : IEntityCreateDto<E> 
    {
        /// <summary>
        /// Create an entity from a createDto instance
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>
        E CreateEntity(C createDto);
    }
}
