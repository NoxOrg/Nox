using FluentValidation;
using Nox.Solution.Validation;
using System;
using System.Collections.Generic;
using Nox.Types;
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

    public List<EntityRelationshipWithType> GetRelationshipsToCreate(Func<string, Type?> getTypeByNameFunc,
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

    public NoxType GetSimpleKeyTypeForEntity(string entityName)
    {
        var entity = this.Domain!.Entities.Single(entity => entity.Name.Equals(entityName));

        return entity.Keys!.Single().Type;
    }
}