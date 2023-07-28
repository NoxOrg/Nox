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
                ShouldGenerateSpecialRelationshipLogicOnThisSide = true
            };

            var pairRelationship = relationship.Related.EntityRelationship;
            if (pairRelationship != null)
            {
                // ManyToMany does not need to be handled as it doesn't have special logic
                // Will be always ignored by default
                if (relationship.Relationship == EntityRelationshipType.OneOrMany ||
                    relationship.Relationship == EntityRelationshipType.ZeroOrMany)
                {
                    isIgnored = true;
                }
                // If ZeroOrOne vs ExactlyOne handle on ExactlyOne side
                else if (pairRelationship.Relationship == EntityRelationshipType.ExactlyOne &&
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

            fullModel.ShouldGenerateSpecialRelationshipLogicOnThisSide = !isIgnored;
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