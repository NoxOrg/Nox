using Nox.Solution;

namespace Nox.Types.EntityFramework;

internal static class EntityRelationshipExtensions
{
    /// <summary>
    /// Defines if the Relation needs to be configured on this side
    /// </summary>
    public static bool ConfigureThisSide(this EntityRelationship relationship)
    {
        var reverseRelationship = relationship.Related.EntityRelationship;
        //Many to Many
        if (relationship.WithMultiEntity && reverseRelationship!.WithMultiEntity)
        {
            return string.Compare(relationship.Entity, reverseRelationship.Entity, StringComparison.InvariantCulture) <= 0;
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

        throw new NotSupportedException($"Can not define Relationship side to configure in EntityFramework {relationship.Name}");
    }

    public static string? GetNavigationPropertyName(this EntityRelationship thisSide, EntityRelationship otherSize)
        => IsSelfReferencingRelationshipTo(thisSide, otherSize) ? null : thisSide.Related.Entity.GetNavigationPropertyName(otherSize);

    public static bool IsSelfReferencingRelationshipTo(this EntityRelationship thisSide, EntityRelationship otherSize)
        => thisSide.Entity == otherSize.Entity;
}