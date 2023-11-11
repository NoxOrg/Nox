using Nox.Domain;
using Nox.Types;

namespace Nox.Application.Factories
{
    public interface IEntityLocalizedFactory<TEntityLocalizedType, TEntityType, TEntityLocalizedCreateDtoType, TEntityLocalizedUpdateDtoType>
        where TEntityType : IEntity
    {
        /// <summary>
        /// Create a localized entity from an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cultureCode"></param>
        /// <returns></returns>
        TEntityLocalizedType CreateLocalizedEntity(TEntityType entity,  CultureCode cultureCode);
        
        /// <summary>
        /// Create a localized entity from a localized DTO.
        /// </summary>
        /// <param name="entityLocalizedCreateDtoType"></param>
        /// <returns></returns>
        TEntityLocalizedType CreateLocalizedEntity(TEntityLocalizedCreateDtoType entityLocalizedCreateDtoType);
        
        /// <summary>
        /// Update a localized entity from a localized DTO.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updateDto"></param>
        void UpdateLocalizedEntity(TEntityLocalizedType entity, TEntityLocalizedUpdateDtoType updateDto);
    }
}
