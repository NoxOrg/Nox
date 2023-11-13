using Nox.Types;
using Nox.Types.Extensions;
using System;
using System.Linq;

namespace Nox.Solution.Extensions;

public static class EntityRelationshipExtensions
{
    /// <summary>
    /// Define the side of the relationship where the foreign key should be generated
    /// if ManyToMany is on Both sides
    /// </summary>
    /// <param name="relationship"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public static bool IsForeignKeyOnThisSide(this EntityRelationship relationship)
    {
        var reverseRelationship = relationship.Related.EntityRelationship;
        //Many to Many
        if (relationship.WithMultiEntity && reverseRelationship!.WithMultiEntity)
        {
            return true;
        }
        // Same =>  pick by entity name sorted
        if (reverseRelationship!.Relationship == relationship.Relationship)
        {
            return string.Compare(relationship.Entity, reverseRelationship.Entity, StringComparison.InvariantCulture) <= 0;
        }

        // Single To Many
        if (relationship.WithSingleEntity && reverseRelationship.WithMultiEntity)
        {
            return true;
        }
        // Many To Single
        if (relationship.WithMultiEntity && reverseRelationship.WithSingleEntity)
        {
            return false;
        }

        // Single to Single pick Exactly one
        if (relationship.WithSingleEntity && reverseRelationship.WithSingleEntity)
        {
            return relationship.Relationship == EntityRelationshipType.ExactlyOne;
        }
        throw new NotSupportedException($"Can not compute foreign key side for {relationship.Name}");
    }

    public static bool IsRequired(this EntityRelationship relationship)
    {
        return
            relationship.Relationship == EntityRelationshipType.ExactlyOne ||
            relationship.Relationship == EntityRelationshipType.OneOrMany;
    }

    /// <summary>
    /// This relationship is a zero or one relation to the other entity
    /// </summary>
    public static bool WithSingleEntity(this EntityRelationship relationship)
    {
        return
            relationship.Relationship == EntityRelationshipType.ExactlyOne ||
            relationship.Relationship == EntityRelationshipType.ZeroOrOne;
    }

    /// <summary>
    /// Entity has a relationship to a collection of the other entity
    /// </summary>
    public static bool WithMultiEntity(this EntityRelationship relationship)
    {
        return
            relationship.Relationship == EntityRelationshipType.ZeroOrMany ||
            relationship.Relationship == EntityRelationshipType.OneOrMany;
    }

    public static bool ShouldUseRelationshipNameAsNavigation(this EntityRelationship relationship)
    {
        var hasReferenceToSingularEntity = relationship.WithSingleEntity();
        var hasReferenceToManyEntities = !hasReferenceToSingularEntity;
        var relationshipNameIsEqualToSingularName = relationship.Name == relationship.Entity;
        var relationshipNameIsEqualToPluralName = relationship.Name == relationship.EntityPlural;

        return
            (hasReferenceToSingularEntity && relationshipNameIsEqualToSingularName) ||
            (hasReferenceToManyEntities && relationshipNameIsEqualToPluralName);

    }

    public static string GetPrimitiveForeignKeyType(this EntityRelationship relationship)
    {
        if (relationship.Related.Entity.HasCompositeKey)
        {
            return $"{relationship.Related.Entity.Name}KeyDto";
        }
        else
        {
            var keyType = relationship.Related.Entity.Keys[0].Type;
            var typeDefinition = new NoxSimpleTypeDefinition()
            {
                Name = $"{relationship.Related.Entity.Name}Id",
                Type = keyType
            };
            var componentType = keyType.GetComponents(typeDefinition).FirstOrDefault().Value;

            return $"System.{componentType.Name}";
        }
    }
}