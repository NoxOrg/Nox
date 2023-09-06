using System.Linq;
using FluentValidation;

namespace Nox.Solution.Validation;

internal class EntityRelationshipKeysValidator : AbstractValidator<Entity>
{
    public EntityRelationshipKeysValidator()
    {
        /*
         1. Owned entity with ZeroOrOne or ExactlyOne relationship keys must be null. 
         2. Keys are mandatory for all other entity usages
         3. Keys must be single for Entity used a Foreign Key 
         */

        When(x => x.Relationships.Any(), () => 
        {
            When(x => x.IsOwnedEntity && x.Relationships
               .Any(x => x.Relationship == EntityRelationshipType.ZeroOrOne || x.Relationship == EntityRelationshipType.ExactlyOne),
               () =>
               {
                   RuleFor(x => x.Keys)
                   .Empty()
                   .WithMessage(x=>string.Format(ValidationResources.OwnedEntityKeysMustBeNull,x.Name));
               })
           .Otherwise(() => {
               RuleFor(x => x.Keys)
               .NotEmpty()
               .WithMessage(x=> string.Format(ValidationResources.EntityKeysRequired,x.Name));
           });
        });

        RuleForEach(x => x.OwnedRelationships)
            .Must(x => x.Related.Entity.Keys.Count == 1)
            .WithMessage((x, r) =>
                string.Format(ValidationResources.RelationEntityDependentMustHaveSingleKey, x.Name, r.Related.Entity.Name, r.Name));
    }
}