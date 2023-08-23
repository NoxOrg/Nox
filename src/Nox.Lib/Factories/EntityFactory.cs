using Nox.Abstractions;
using Nox.Solution;

namespace Nox.Factories;

/// <summary>
/// Open Generic Factory for Entities
/// </summary>
public class EntityFactory<T, E> : IEntityFactory<T, E> where T : class where E : IEntity, new()
{
    public NoxSolution NoxSolution { get; }
    public IEntityMapper<E> EntityMapper { get; }

    public EntityFactory(NoxSolution noxSolution, IEntityMapper<E> entityMapper)
    {
        NoxSolution = noxSolution;
        EntityMapper = entityMapper;
    }

    public E CreateEntity(T dto)
    {
        var entityDefinition = NoxSolution.Domain!.GetEntityByName(typeof(E).Name);
        E entity = new();
        EntityMapper.MapToEntity(entity, entityDefinition, dto);
        return entity;
    }   
}