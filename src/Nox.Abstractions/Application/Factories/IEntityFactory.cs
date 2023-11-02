using Nox.Application.Dto;
using Nox.Domain;

namespace Nox.Application.Factories
{
    /// <summary>
    /// Factory for Entities
    /// </summary>
    public interface IEntityFactory<TEntityType, TCreateEntityDtoType, TUpdateEntityDtoType> where TEntityType : IEntity where TCreateEntityDtoType : IEntityDto<TEntityType> where TUpdateEntityDtoType : IEntityDto<TEntityType>
    {
        /// <summary>
        /// Create an entity from a createDto instance
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>
        TEntityType CreateEntity(TCreateEntityDtoType createDto);

        /// <summary>
        /// Updates an entity using an updateDto
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <param name="updateDto">Updated dto</param>
        void UpdateEntity(TEntityType entity, TUpdateEntityDtoType updateDto);

        /// <summary>
        /// Updates some properties of an entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <param name="updatedProperties">Properties to update</param>
        void PartialUpdateEntity(TEntityType entity, Dictionary<string, dynamic> updatedProperties, Types.CultureCode cultureCode);
    }
}
