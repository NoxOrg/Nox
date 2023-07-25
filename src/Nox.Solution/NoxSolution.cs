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

        if (entity?.Relationships == null)
        {
            return fullRelationshipModels;
        }

        foreach (var relationship in entity.Relationships)
        {
            var isIgnored = false;
            var fullModel = new EntityRelationshipWithType
            {
                Relationship = relationship,
                RelationshipEntityType = getTypeByNameFunc(relationship.Entity)!,
                // TODO: is this still needed?
                ShouldBeMapped = true
            };

            var pairRelationship = relationship.Related.EntityRelationship;
            if (pairRelationship != null)
            {
                // If ZeroOrMany vs OneOrMany handle on oneOrMany side
                if (pairRelationship.Relationship == EntityRelationshipType.OneOrMany &&
                    relationship.Relationship == EntityRelationshipType.ZeroOrMany)
                {
                    isIgnored = true;
                }
                // If ZeroOrOne vs ExactlyOne handle on ExactlyOne side
                if (pairRelationship.Relationship == EntityRelationshipType.ExactlyOne &&
                    relationship.Relationship == EntityRelationshipType.ZeroOrOne)
                {
                    isIgnored = true;
                }
                // If same type on both sides cover on first by ascending alphabetical sort
                else if (pairRelationship.Relationship == relationship.Relationship &&
                         // Ascending alphabetical sort
                         string.Compare(relationship.Entity, pairRelationship.Entity,
                             StringComparison.InvariantCulture) > 0)
                {
                    isIgnored = true;
                }
            }

            fullModel.ShouldBeMapped = !isIgnored;
            fullRelationshipModels.Add(fullModel);
        }

        return fullRelationshipModels;
    }

    public NoxType GetSimpleKeyTypeForEntity(string entityName)
    {
        var entity = this.Domain!.Entities.Single(entity => entity.Name.Equals(entityName));

        return entity.Keys!.Single().Type;
    }
}