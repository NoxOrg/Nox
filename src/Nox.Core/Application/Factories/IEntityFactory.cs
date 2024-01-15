using Nox.Application.Dto;
using Nox.Domain;

namespace Nox.Application.Factories
{
    /// <summary>
    /// Factory for Entities
    /// </summary>
    public interface IEntityFactory<TEntityType, TCreateEntityDtoType, TUpdateEntityDtoType> where TEntityType : IEntity 
    {
        /// <summary>
        /// Create an entity from a createDto instance
        /// </summary>
        /// <param name="createDto"></param>
        /// <param name="cultureCode"></param>
        /// <returns></returns>
        Task<TEntityType> CreateEntityAsync(TCreateEntityDtoType createDto, Types.CultureCode cultureCode);

        /// <summary>
        /// Updates an entity using an updateDto
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <param name="updateDto">Updated dto</param>
        /// <param name="cultureCode">Culture code</param>
        Task UpdateEntityAsync(TEntityType entity, TUpdateEntityDtoType updateDto, Types.CultureCode cultureCode);

        /// <summary>
        /// Updates some properties of an entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <param name="updatedProperties">Properties to update</param>
        /// <param name="cultureCode">Culture code</param>
        Task PartialUpdateEntityAsync(TEntityType entity, Dictionary<string, dynamic> updatedProperties, Types.CultureCode cultureCode);
    }
}
