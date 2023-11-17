using System.Linq;
using FluentValidation;

namespace Nox.Solution.Validation;

/// <summary>
/// Validator for ensuring the validity of unique attribute constraints.
/// </summary>
public class UniqueAttributeConstraintValidator : AbstractValidator<UniqueAttributeConstraint>
{
    private readonly Entity _entity;

    /// <summary>
    /// Initializes a new instance of the <see cref="UniqueAttributeConstraintValidator"/> class.
    /// </summary>
    /// <param name="entity">The entity for which unique attribute constraints are being validated.</param>
    public UniqueAttributeConstraintValidator(Entity entity)
    {
        _entity = entity;

       // Unique constraint must have at least one attribute or relationship
       RuleFor(ua => ua).Must(ua => ua.AttributeNames.Count > 0 || ua.RelationshipNames.Count > 0)
            .WithMessage((_, ua) => string.Format(ValidationResources.EntityUniqueAttributeConstraintMustHaveAtLeastOneAttributeOrRelationship, ua.Name));

        // Attribute names must be unique
        RuleForEach(ua => ua.AttributeNames)
            .SetValidator(v => new UniquePropertyValidator<string>(v.AttributeNames, x => x, "attribute name in unique attribute constraint"));

        // Attribute names must exist in the entity
        RuleForEach(ua => ua.AttributeNames).Must(ReferenceExistingAttribute)
            .WithMessage((_, attribute) => string.Format(ValidationResources.EntityUniqueAttributeConstraintCanReferenceOnlyExistingAttributes, attribute, EntityAttributeNames, EntityKeyNames));

        // Relationship names must be unique
        RuleForEach(ua => ua.RelationshipNames)
            .SetValidator(v => new UniquePropertyValidator<string>(v.RelationshipNames, x => x, "relationship name in unique attribute constraint"));

        // Relationship names must exist in the entity
        RuleForEach(ua => ua.RelationshipNames).Must(ReferenceExistingRelationship)
            .WithMessage((_, relationship) => string.Format(ValidationResources.EntityUniqueAttributeConstraintCanReferenceOnlyExistingRelationships, relationship, EntityRelationshipNames));

        // Only Zero/One To Many relationships can be used
        RuleForEach(ua => ua.RelationshipNames)
            .Must((ua, relationshipName, _) => _entity.Relationships.First(r => r.Name == relationshipName).WithSingleEntity && _entity.Relationships.First(r => r.Name == relationshipName).Related.EntityRelationship.WithMultiEntity)
            .WithMessage((_, relationship) => string.Format(ValidationResources.OnlySingleToManyRelationshipsCanBeUsedInUniqueConstraint, relationship));
    }

    /// <summary>
    /// Checks if the provided attribute name exists in the entity's attributes or keys.
    /// </summary>
    /// <param name="attributeName">The attribute name to check.</param>
    /// <returns>True if the attribute exists in the entity, otherwise false.</returns>
    private bool ReferenceExistingAttribute(string attributeName)
    {
        var entity = _entity.Attributes?.FirstOrDefault(e => e.Name == attributeName);

        var keys = _entity.Keys?.FirstOrDefault(e => e.Name == attributeName);

        return entity is not null || keys is not null;
    }

    /// <summary>
    /// Checks if the provided relationship name exists in the entity's relationships.
    /// </summary>
    /// <param name="relationshipName">Name of the relationship.</param>
    /// <returns>True if the relationship exists in the entity, otherwise false</returns>
    private bool ReferenceExistingRelationship(string relationshipName)
    {
        return _entity.Relationships.FirstOrDefault(e => e.Name == relationshipName) != null;
    }

    private string EntityAttributeNames => string.Join(", ", _entity.Attributes?.Select(x => x.Name) ?? Enumerable.Empty<string>());
    private string EntityKeyNames => string.Join(", ", _entity.Keys?.Select(x => x.Name) ?? Enumerable.Empty<string>());
    private string EntityRelationshipNames => string.Join(", ", _entity.Relationships?.Select(x => x.Name) ?? Enumerable.Empty<string>());
}