using Nox.Domain;

namespace Nox.Application
{
    public interface IEntityFactory<T,E> where T : class where E : IEntity
    {
        E CreateEntity(T dto);
    }
}
