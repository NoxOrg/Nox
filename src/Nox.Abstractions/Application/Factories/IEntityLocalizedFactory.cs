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
        /// <param name="withAttributes"></param>
        /// <returns></returns>
        TEntityLocalizedType CreateLocalizedEntity(TEntityType entity, CultureCode cultureCode, bool withAttributes = true);

        /// <summary>
        /// Updates a localized entity from an update dto.
        /// </summary>
        /// <param name="localizedEntity"></param>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        void UpdateLocalizedEntity(TEntityLocalizedType localizedEntity, TUpdateEntityDtoType updateDto);

        /// <summary>
        /// Updates some properties of a localized entity.
        /// </summary>
        /// <param name="localizedEntity"></param>
        /// <param name="updatedProperties"></param>
        void PartialUpdateLocalizedEntity(TEntityLocalizedType localizedEntity, Dictionary<string, dynamic> updatedProperties);
    }
}