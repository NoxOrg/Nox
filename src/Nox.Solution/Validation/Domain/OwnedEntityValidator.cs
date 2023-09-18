
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution.Validation;

internal class OwnedEntityValidator : AbstractValidator<Entity>
{
    public OwnedEntityValidator(IEnumerable<Entity> entities)
    {
        /*
            1. Owned entity with ZeroOrOne or ExactlyOne relationship keys must be null. 
            2. Keys are mandatory for all other entity usages
            3. Keys must be single for Entity used a Foreign Key 
        */
        When(e => e.Relationships.Any(), () =>
        {
            When(e => e.Relationships.Any(x => x.Relationship == EntityRelationshipType.ZeroOrOne || x.Relationship == EntityRelationshipType.ExactlyOne), () =>
            {
                RuleFor(e => e.Keys)
                    .Empty()
                    .WithMessage(e => string.Format(ValidationResources.OwnedEntityKeysMustBeNull, e.Name));
            })
            .Otherwise(() =>
            {
                RuleFor(e => e.Keys)
                   .NotEmpty()
                   .WithMessage(e => string.Format(ValidationResources.EntityKeysRequired, e.Name));
            });
        });

        // Owned entity cannot be auditable
        RuleFor(e => e.Persistence!.IsAudited)
            .NotEqual(true)
            .WithMessage(e => string.Format(ValidationResources.EntityOwnedCannotBeAuditable, e.Name));

        // Owned entity cannot have relationships to other entities
        RuleFor(e => e.Relationships.Any())
            .NotEqual(true)
            .WithMessage(e => string.Format(ValidationResources.EntityOwnedCannotHaveRelationships, e.Name, e.OwnerEntity?.Name));

        // Owned entity cannot be related to other entities
        RuleFor(e => IsRelatedToOtherEntities(e, entities))
            .NotEqual(true)
            .WithMessage(e => string.Format(ValidationResources.EntityOwnedCannotBeRelatedToOtherEntities, e.Name, e.OwnerEntity?.Name));
    }

    private static bool IsRelatedToOtherEntities(Entity ownedEntity, IEnumerable<Entity> entities)
        => entities.Any(e => e.Relationships.Any(er => er.Entity == ownedEntity.Name));
}
