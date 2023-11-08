using Nox.Domain;
using Nox.Types;

namespace Nox.Application.Factories
{
    public interface IEntityLocalizedFactory<out TEntityLocalizedType, in TEntityType>
        where TEntityType : IEntity
    {
        /// <summary>
        /// Create a localized entity from an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntityLocalizedType CreateLocalizedEntity(TEntityType entity,  CultureCode cultureCode);
    }
}
