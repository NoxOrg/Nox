using Nox.Application.Dto;
using Nox.Domain;
using Nox.Types;

namespace Nox.Application.Factories
{
    public interface IEntityLocalizedFactory<TEntityLocalizedType, in TEntityType, in TUpdateEntityDtoType>
        where TEntityType : IEntity
        where TUpdateEntityDtoType : IEntityDto<TEntityType>
    {
        /// <summary>
        /// Create a localized entity from an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cultureCode"></param>
        /// <param name="copyEntityAttributes"></param>
        /// <returns></returns>
        TEntityLocalizedType CreateLocalizedEntity(TEntityType entity, CultureCode cultureCode, bool copyEntityAttributes = true);

        /// <summary>
        /// Updates a localized entity from an update dto.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updateDto"></param>
        /// <param name="cultureCode"></param>
        /// <returns></returns>
        Task UpdateLocalizedEntityAsync(TEntityType entity, TUpdateEntityDtoType updateDto, CultureCode cultureCode);

        /// <summary>
        /// Updates some properties of a localized entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updatedProperties"></param>
        /// <param name="cultureCode"></param>
        Task PartialUpdateLocalizedEntityAsync(TEntityType entity, Dictionary<string, dynamic> updatedProperties, CultureCode cultureCode);
    }
}