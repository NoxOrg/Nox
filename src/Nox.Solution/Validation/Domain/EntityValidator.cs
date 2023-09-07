using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Nox.Types;

namespace Nox.Solution.Validation
{
    internal class EntityValidator : AbstractValidator<Entity>
    {
        public EntityValidator(IEnumerable<Entity>? entities, Application? application)
        {
            if (entities == null) return;

            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage(t => string.Format(ValidationResources.EntityNameEmpty));

            RuleFor(e => e.ApplyDefaults())
                .NotEqual(false)
                .WithMessage(e => string.Format(ValidationResources.EntityDefaultsFalse, e.Name));

            RuleFor(e => e.Persistence!)
                .SetValidator(e => new EntityPersistenceValidator(e));

            RuleForEach(e => e.Relationships)
                .SetValidator(x => new EntityItemUniquenessValidator<EntityRelationship>(x, t => t.Name, nameof(x.Relationships)))
                .SetValidator(e => new EntityRelationshipValidator(e.Name, entities))
                .SetValidator(e => new UniquePropertyValidator<EntityRelationship>(e.Relationships, x => x.Name, "entity relation"));

            RuleForEach(e => e.OwnedRelationships)
                .SetValidator(e => new EntityRelationshipValidator(e.Name, entities, requiresCorrespondingRelationship: false))
                .SetValidator(x => new EntityItemUniquenessValidator<EntityRelationship>(x, t => t.Name, nameof(x.OwnedRelationships)))
                .SetValidator(e => new UniquePropertyValidator<EntityRelationship>(e.OwnedRelationships, x => x.Name, "entity owned relation"));

            RuleForEach(e => e.OwnedRelationships)
                .Must(x => x.Related.Entity.Keys.Count <= 1)
                .WithMessage((x, r) => string.Format(ValidationResources.RelationEntityDependentMustHaveSingleKey, x.Name, r.Related.Entity.Name, r.Name));

            RuleForEach(e => e.Relationships)
                .Must(x => x.Related.Entity.Keys.Count <= 1)
                .WithMessage((x, r) => string.Format(ValidationResources.RelationEntityDependentMustHaveSingleKey, x.Name, r.Related.Entity.Name, r.Name));

            RuleForEach(e => e.Queries)
                .SetValidator(e => new DomainQueryValidator(e.Queries, e.Name));

            RuleForEach(e => e.Commands)
                .SetValidator(v => new DomainCommandValidator(v.Commands, v.Name));

            RuleForEach(p => p.Keys)
                .SetValidator(e => new PropertyNameValidator(e.Name, "entity key"))
                .SetValidator(v => new EntityKeyValidator(v.Name, "entity keys"))
                .SetValidator(x => new EntityItemUniquenessValidator<NoxSimpleTypeDefinition>(x, t => t.Name, nameof(x.Keys)))
                .SetValidator(e => new UniquePropertyValidator<NoxSimpleTypeDefinition>(e.Keys, x => x.Name, "entity key"));

            RuleForEach(p => p.Keys!.Where(x => x.Type == NoxType.Nuid))
                .SetValidator(v => new NuidKeyValidator(v));

            RuleForEach(p => p.Attributes)
                .SetValidator(e => new PropertyNameValidator(e.Name, "entity attribute"))
                .SetValidator(v => new SimpleTypeValidator($"an Attribute of entity '{v.Name}'", "entity attributes"))
                .SetValidator(e => new UniquePropertyValidator<NoxSimpleTypeDefinition>(e.Attributes, x => x.Name, "entity attribute"))
                .SetValidator(x => new EntityItemUniquenessValidator<NoxSimpleTypeDefinition>(x, t => t.Name, nameof(x.Attributes)));

            var domainEvents = entities
                .Where(x => x.Events != null)
                .SelectMany(x => x.Events!)
                .ToList();

            var appEvents = new List<ApplicationEvent>();
            if (application is { Events: not null } && application.Events.Any())
            {
                appEvents.AddRange(application.Events!);
            }

            RuleForEach(e => e.Events)
                .SetValidator(e => new DomainEventValidator(domainEvents, appEvents, e.Name));

            RuleForEach(e => e.UniqueAttributeConstraints)
                .SetValidator(v => new UniqueAttributeConstraintValidator(v))
                .SetValidator(e => new UniquePropertyValidator<UniqueAttributeConstraint>(e.UniqueAttributeConstraints, x => x.Name, "unique attribute constraint"))
                .SetValidator(e => new UniquePropertyValidator<UniqueAttributeConstraint>(e.UniqueAttributeConstraints, x => string.Join(",", x.AttributeNames.OrderBy(a => a)), "unique attribute constraint attribute names"));

            /*
            1. Owned entity with ZeroOrOne or ExactlyOne relationship keys must be null. 
            2. Keys are mandatory for all other entity usages
            3. Keys must be single for Entity used a Foreign Key 
            */
            When(x => x.Relationships.Any(), () =>
            {
                When(x => x.IsOwnedEntity
                    && x.Relationships.Any(x => x.Relationship == EntityRelationshipType.ZeroOrOne || x.Relationship == EntityRelationshipType.ExactlyOne),
                   () =>
                   {
                       RuleFor(x => x.Keys)
                       .Empty()
                       .WithMessage(x => string.Format(ValidationResources.OwnedEntityKeysMustBeNull, x.Name));
                   })
               .Otherwise(() => {
                   RuleFor(x => x.Keys)
                   .NotEmpty()
                   .WithMessage(x => string.Format(ValidationResources.EntityKeysRequired, x.Name));
               });
            });
        }
    }
}