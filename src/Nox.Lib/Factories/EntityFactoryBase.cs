using Nox.Application.Dto;
using Nox.Domain;

namespace Nox.Factories
{

    /// <summary>
    /// Open Generic Factory for Entities
    /// </summary>
    public abstract class EntityFactoryBase<T, E> : IEntityFactory<T, E> where T : class, IEntityCreateDto<E> where E : IEntity, new()
    {        
        public E CreateEntity(T createDto)
        {
            return createDto.ToEntity();
        }
    }
}
