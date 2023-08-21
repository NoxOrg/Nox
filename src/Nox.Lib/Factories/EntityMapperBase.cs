using Microsoft.Extensions.DependencyInjection;
using Nox.Domain;
using Nox.Types;
using Entity = Nox.Solution.Entity;
using Nox.Solution;
using System.Collections.Generic;

namespace Nox.Factories;

public abstract class EntityMapperBase<E>: IEntityMapper<E> where E : Domain.IEntity
{
    public NoxSolution NoxSolution { get; }
    public IServiceProvider ServiceProvider { get; }

    public EntityMapperBase(NoxSolution noxSolution, IServiceProvider serviceProvider)
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
    public abstract void PartialMapToEntity(E entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties, HashSet<string> deletedPropertyNames);
}