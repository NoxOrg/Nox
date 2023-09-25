using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution.Validation;

internal class OwnedEntityValidator : AbstractValidator<Entity>
{
    public OwnedEntityValidator(IEnumerable<Entity> entities)
    {
        //  Owned entity with ZeroOrOne or ExactlyOne relationship => keys must be null
        When(e => e.OwnerEntity!.OwnedRelationships.Any(r => r.Entity == e.Name && (r.Relationship == EntityRelationshipType.ZeroOrOne || r.Relationship == EntityRelationshipType.ExactlyOne)), () =>
        {
            RuleFor(e => e.Keys)
                .Empty()
                .WithMessage(e => string.Format(ValidationResources.OwnedEntityKeysMustBeNull, e.Name));
        })
        //  Owned entity with ZeroOrMany or OneOrMeny relationship => keys must be defined
        .Otherwise(() =>
        {
            RuleFor(e => e.Keys)
                .NotEmpty()
                .WithMessage(e => string.Format(ValidationResources.EntityKeysRequired, e.Name));
        });

        // Owned entity cannot be auditable
        RuleFor(e => e.Persistence!.IsAudited)
            .NotEqual(true)
            .WithMessage(e => string.Format(ValidationResources.EntityOwnedCannotBeAuditable, e.Name));

        // Owned entity cannot have relationships to other entities
        RuleFor(e => e.Relationships.Any())
            .NotEqual(true)
            .WithMessage(e => string.Format(ValidationResources.EntityOwnedCannotHaveRelationships, e.Name));

        // Owned entity cannot be related to other entities
        RuleFor(e => IsRelatedToOtherEntities(e, entities))
            .NotEqual(true)
            .WithMessage(e => string.Format(ValidationResources.EntityOwnedCannotBeRelatedToOtherEntities, e.Name));
    }

    private static bool IsRelatedToOtherEntities(Entity ownedEntity, IEnumerable<Entity> entities)
        => entities.Any(e => e.Relationships.Any(er => er.Entity == ownedEntity.Name));
}
