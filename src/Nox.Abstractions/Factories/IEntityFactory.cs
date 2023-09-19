using Nox.Application.Dto;
using Nox.Domain;

namespace Nox.Factories
{
    /// <summary>
    /// Factory for Entities
    /// </summary>
    public interface IEntityFactory<E, C, U> where E : IEntity where C : IEntityDto<E> where U : IEntityDto<E>
    {
        /// <summary>
        /// Create an entity from a createDto instance
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>
        E CreateEntity(C createDto);

        /// <summary>
        /// Updates an entity using a dto
        /// </summary>
        /// <param name="entity">Entity to Update</param>
        /// <param name="updateDto">Dto</param>
        void UpdateEntity(E entity, U updateDto);
    }
}
