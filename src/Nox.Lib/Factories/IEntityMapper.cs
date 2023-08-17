﻿using Microsoft.Extensions.DependencyInjection;
using Nox.Domain;
using Nox.Types;
using Entity = Nox.Solution.Entity;
using Nox.Solution;

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
    /// <summary>
    /// Update some entity properties
    /// </summary>    
    /// <param name="entity">Entity to update</param>
    /// <param name="entityDefinition">Entity Definition</param>
    /// <param name="updatedProperties">Properties to update</param>
    /// <param name="deletedPropertyNames">Properties to unset</param>
    void PartialMapToEntity(E entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties, List<string> deletedPropertyNames);
}

public abstract class EntityMapperBase<E>: IEntityMapper<E> where E : IEntity
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
    public abstract void PartialMapToEntity(E entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties, List<string> deletedPropertyNames);
}