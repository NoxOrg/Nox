using Nox.Application.Dto;
using Nox.Domain;

namespace Nox.Factories
{
    /// <summary>
    /// Create and entity from a createDto
    /// </summary>
    public interface IEntityFactory<T, E> where T : IEntityCreateDto<E> where E : IEntity
    {
        E CreateEntity(T createDto);
    }
}
