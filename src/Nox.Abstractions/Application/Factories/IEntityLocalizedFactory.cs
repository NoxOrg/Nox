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
        /// <returns></returns>
        TEntityLocalizedType CreateLocalizedEntity(TEntityType entity, CultureCode cultureCode);

        /// <summary>
        /// Updates a localized entity from an update dto.
        /// </summary>
        /// <param name="localizedEntity"></param>
        /// <param name="updateDto"></param>
        /// <param name="cultureCode"></param>
        /// <returns></returns>
        void UpdateLocalizedEntity(TEntityLocalizedType localizedEntity, TUpdateEntityDtoType updateDto, CultureCode cultureCode);

        /// <summary>
        /// Updates some properties of a localized entity.
        /// </summary>
        /// <param name="localizedEntity"></param>
        /// <param name="updatedProperties"></param>
        /// <param name="cultureCode"></param>
        void PartialUpdateEntity(TEntityLocalizedType localizedEntity, Dictionary<string, dynamic> updatedProperties, CultureCode cultureCode);
    }
}