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
        /// <returns></returns>
        TEntityLocalizedType CreateLocalizedEntity(TEntityType entity, CultureCode cultureCode);

        /// <summary>
        /// Updates a localized entity from an update dto.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void UpdateLocalizedEntity(TEntityLocalizedType localizedEntity, TUpdateEntityDtoType updateDto, CultureCode cultureCode);
    }
}
