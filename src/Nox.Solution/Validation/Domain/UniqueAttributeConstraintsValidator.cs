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

        // Attribute names must be unique  
        RuleForEach(ua => ua.AttributeNames)
            .SetValidator(v => new UniquePropertyValidator<string>(v.AttributeNames, x => x, "attribute name in unique attribute constraint"));

        // Attribute names must exist in the entity
        RuleForEach(ua => ua.AttributeNames).Must(ReferenceExistingEntity)
            .WithMessage((_, attribute) => string.Format(ValidationResources.AttributeNameMustExistInEntity, attribute, EntityAttributeNames, EntityKeyNames));
    }

    /// <summary>
    /// Checks if the provided attribute name exists in the entity's attributes or keys.
    /// </summary>
    /// <param name="attributeName">The attribute name to check.</param>
    /// <returns>True if the attribute exists in the entity, otherwise false.</returns>
    private bool ReferenceExistingEntity(string attributeName)
    {
        var entity = _entity.Attributes?.FirstOrDefault(e => e.Name == attributeName);

        var keys = _entity.Keys?.FirstOrDefault(e => e.Name == attributeName);

        return entity is not null || keys is not null;
    }

    private string EntityAttributeNames => string.Join(", ", _entity.Attributes?.Select(x => x.Name) ?? Enumerable.Empty<string>());
    private string EntityKeyNames => string.Join(", ", _entity.Keys?.Select(x => x.Name) ?? Enumerable.Empty<string>());
}