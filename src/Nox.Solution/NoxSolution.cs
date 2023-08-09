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

    internal static bool ShouldGenerateForeignOnThisSide(EntityRelationship relationship)
    {
        var isIgnored = false;

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

        return !isIgnored;
    }

    internal static bool HasRelationshipWithSingularEntity(EntityRelationship relationship)
    {
        return
            relationship.Relationship == EntityRelationshipType.ExactlyOne ||
            relationship.Relationship == EntityRelationshipType.ZeroOrOne;
    }

    internal static bool ShouldUseRelationshipNameAsNavigation(EntityRelationship relationship)
    {
        var hasReferenceToSingularEntity = HasRelationshipWithSingularEntity(relationship);
        var hasReferenceToManyEntities = !hasReferenceToSingularEntity;
        var relationshipNameIsEqualToSingularName = relationship.Name == relationship.Entity;
        var relationshipNameIsEqualToPluralName = relationship.Name == relationship.EntityPlural;

        return
            (hasReferenceToSingularEntity && relationshipNameIsEqualToSingularName) ||
            (hasReferenceToManyEntities && relationshipNameIsEqualToPluralName);

    }

    internal static bool IsManyRelationshipOnOtherSide(EntityRelationship relationship)
    {
        return
            relationship.Related.EntityRelationship.Relationship == EntityRelationshipType.ZeroOrMany ||
            relationship.Related.EntityRelationship.Relationship == EntityRelationshipType.OneOrMany;

    }

    public NoxType GetSimpleKeyTypeForEntity(string entityName)
    {
        var entity = this.Domain!.Entities.Single(entity => entity.Name.Equals(entityName));

        return entity.Keys!.Single().Type;
    }
}