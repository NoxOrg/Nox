using FluentValidation;
using Nox.Solution.Validation;
using Nox.Types;
using Nox.Types.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution;

public class NoxSolution : Solution
{
    public string? RootYamlFile { get; internal set; }

    internal void Validate()
    {
        var validator = new SolutionValidator();
        validator.ValidateAndThrow(this);
    }

    public List<EntityRelationshipWithType> GetRelationshipsToCreate(
        Func<string, Type?> getTypeByNameFunc,
        Entity entity)
    {
        var fullRelationshipModels = new List<EntityRelationshipWithType>();

        if (entity?.Relationships != null)
        {
            foreach (var relationship in entity.Relationships)
            {
                fullRelationshipModels.Add(new EntityRelationshipWithType
                {
                    Relationship = relationship,
                    RelationshipEntityType = getTypeByNameFunc(relationship.Entity)!
                });
            }
        }

        return fullRelationshipModels;
    }

    public List<EntityRelationshipWithType> GetOwnedRelationshipsToCreate(
        Func<string, Type?> getTypeByNameFunc,
        Entity entity)
    {
        var fullRelationshipModels = new List<EntityRelationshipWithType>();

        if (entity?.OwnedRelationships != null)
        {
            foreach (var relationship in entity.OwnedRelationships)
            {
                fullRelationshipModels.Add(new EntityRelationshipWithType
                {
                    Relationship = relationship,
                    RelationshipEntityType = getTypeByNameFunc(relationship.Entity)!
                });
            }
        }

        return fullRelationshipModels;
    }

    public bool IsOwnedEntity(Entity entity)
    {
        if (Domain == null)
        {
            return false;
        }

        foreach(var domainEntity in Domain.Entities)
        {
            if (domainEntity?.OwnedRelationships != null)
            {
#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
                foreach (var relationship in domainEntity.OwnedRelationships)
                {
                    if (relationship.Entity.Equals(entity.Name))
                    {
                        return true;
                    }
                }
#pragma warning restore S3267 // Loops should be simplified with "LINQ" expressions
            }
        }

        return false;
    }

    /// <summary>
    /// Key Nox.Type for and Entity with single key . If NoxType is Entity again, then we recursively get the entity primary key type!
    /// </summary>
    /// <param name="entityName"></param>
    /// <returns></returns>
    public NoxType GetSingleKeyTypeForEntity(string entityName)
    {
        var entity = Domain!.Entities.Single(entity => entity.Name.Equals(entityName));

        return entity.Keys!.Single().Type;
    }

    /// <summary>
    /// Key Nox.Type for a key definition, If type is Entity again, then we recursively get the entity primary key type!
    /// </summary>
    /// <param name="keyDefinition"></param>
    /// <returns></returns>
    public NoxType GetSingleTypeForKey(NoxSimpleTypeDefinition keyDefinition)
    {
        if(keyDefinition.Type != NoxType.Entity)
        {
            return keyDefinition.Type;
        }
        // Obtain the reference entity
        var entity = Domain!.Entities.Single(entity => entity.Name.Equals(keyDefinition.EntityTypeOptions!.Entity));

        return GetSingleTypeForKey(entity.Keys![0]);
    }

    /// <summary>
    /// Key Primitive for a key definition, If type is Entity again, then we recursively get the entity primary key type!
    /// </summary>
    /// <param name="keyDefinition"></param>
    /// <returns></returns>
    public string GetSinglePrimitiveTypeForKey(NoxSimpleTypeDefinition keyDefinition)
    {
        if (keyDefinition.Type != NoxType.Entity)
        {
            return keyDefinition.Type.GetComponents(keyDefinition).Single().Value.ToString();
        }
        // Obtain the reference entity
        var entity = Domain!.Entities.Single(entity => entity.Name.Equals(keyDefinition.EntityTypeOptions!.Entity));

        return GetSinglePrimitiveTypeForKey(entity.Keys![0]);
    }


    /// <summary>
    /// Key Primitive type for and Entity with single key 
    /// </summary>
    /// <param name="entityName"></param>
    /// <returns></returns>
    public string GetSingleKeyPrimitiveTypeForEntity(string entityName)
    {
        var entity = Domain!.Entities.Single(entity => entity.Name.Equals(entityName));
        var key = entity.Keys!.Single();
        // Single, because keys cannot be compound type
        return key.Type.GetComponents(key).Single().Value.ToString();
    }
}