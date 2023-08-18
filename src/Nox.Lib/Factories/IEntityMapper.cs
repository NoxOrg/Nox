using Microsoft.Extensions.DependencyInjection;
using Nox.Types;
using Entity = Nox.Solution.Entity;
using Nox.Solution;
using Nox.Abstractions;

namespace Nox.Factories;

/// <summary>
/// Service to set the entity properties 
/// </summary>
public interface IEntityMapper<E> where E : IEntity
{
    /// <summary>
    /// Set the entity properties with the dto data
    /// </summary>    
    void MapToEntity(E entity, Entity entityDefinition, dynamic dto);
}

public abstract class EntityMapperBase<E>: IEntityMapper<E> where E : IEntity
{
    public NoxSolution NoxSolution { get; }
    public IServiceProvider ServiceProvider { get; }

    protected EntityMapperBase(NoxSolution noxSolution, IServiceProvider serviceProvider)
    {
        NoxSolution = noxSolution;
        ServiceProvider = serviceProvider;
    }

    public N? CreateNoxType<N>(Entity entityDefinition, string attributeName, dynamic? value) where N : INoxType
    {
        var typeFactory = ServiceProvider.GetService<INoxTypeFactory<N>>();
        return typeFactory!.CreateNoxType(entityDefinition, attributeName, value);
    }

    public abstract void MapToEntity(E entity, Entity entityDefinition, dynamic dto);    
}