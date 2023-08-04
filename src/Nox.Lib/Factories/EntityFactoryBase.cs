using Microsoft.Extensions.DependencyInjection;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Entity = Nox.Solution.Entity;

namespace Nox.Factories;

public abstract class EntityFactoryBase<T, E> : IEntityFactory<T, E> where T : class where E : IEntity, new()
{
    public EntityFactoryBase(NoxSolution noxSolution, IServiceProvider serviceProvider)
    {
        NoxSolution = noxSolution;
        ServiceProvider = serviceProvider;
    }

    public NoxSolution NoxSolution { get; }
    public IServiceProvider ServiceProvider { get; }

    public E CreateEntity(T dto)
    {
        var entityDefinition = NoxSolution.Domain!.GetEntityByName(typeof(E).Name);
        E entity = new();
        MapEntity(entity, entityDefinition, dto);
        return entity;
    }
    protected N? CreateNoxType<N>(Entity entityDefinition, string attributeName, dynamic? value) where N : INoxType
    {
        var typeFactory = ServiceProvider.GetService<INoxTypeFactory<N>>();
        return typeFactory!.CreateNoxType(entityDefinition, attributeName, value);
    }
    protected abstract void MapEntity(E entity, Entity entityDefinition, T dto);
}

