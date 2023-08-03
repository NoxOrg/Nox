using Nox.Domain;
using Nox.Solution;

namespace Nox.Application;

public abstract class EntityFactoryBase<T, E> : IEntityFactory<T, E> where T : class where E : IEntity
{
    public EntityFactoryBase(NoxSolution noxSolution)
    {
        NoxSolution = noxSolution;
    }

    public NoxSolution NoxSolution { get; }

    public E CreateEntity(T dto)
    {
        var entityDefinition = NoxSolution.Domain!.GetEntityByName(nameof(E));
        var entity = default(E)!;
        MapEntity(entity, entityDefinition, dto);
        return entity;
    }

    protected abstract void MapEntity(E entity, Entity entityDefinition, T dto);
}

