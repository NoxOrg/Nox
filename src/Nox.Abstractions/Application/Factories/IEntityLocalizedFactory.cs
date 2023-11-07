using Nox.Domain;
using Nox.Types;

namespace Nox.Application.Factories
{
    public interface IEntityLocalizedFactory<out TEntityLocalizedType, in TEntityType, in TEntityLocalizedDtoType>
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
        /// Create a localized entity from an entity localized dto.
        /// </summary>
        /// <param name="entityLocalizedDto"></param>
        /// <returns></returns>
        TEntityLocalizedType CreateLocalizedEntityFromDto(TEntityLocalizedDtoType entityLocalizedDto);
    }
}
