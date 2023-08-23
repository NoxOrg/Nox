using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Nox.Solution.Events;
using Nox.Types;

namespace Nox.Solution.Validation
{
    internal class EntityValidator : AbstractValidator<Entity>
    {
        private readonly IList<Entity> _entities = new List<Entity>();

        public EntityValidator(IEnumerable<Entity>? entities, Application? application)
        {
            if (entities == null) return;
            _entities = (IList<Entity>)entities;

            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage(t => string.Format(ValidationResources.EntityNameEmpty));

            RuleFor(e => e.ApplyDefaults())
                .NotEqual(false)
                .WithMessage(e => string.Format(ValidationResources.EntityDefaultsFalse, e.Name));

            RuleFor(e => e.Name).Must(MustHaveUniqueName)
                .WithMessage(e => string.Format(ValidationResources.EntityNameDuplicate, e.Name));

            RuleForEach(e => e.Relationships)
                .SetValidator(e => new EntityRelationshipValidator(e.Name, _entities))
                .SetValidator(e => new UniquePropertyValidator<EntityRelationship>(e.Relationships, x => x.Name, "entity relation"));

            RuleForEach(e => e.OwnedRelationships)
                .SetValidator(e => new EntityRelationshipValidator(e.Name, _entities, bindToOtherRelationship: false))
                .SetValidator(e => new UniquePropertyValidator<EntityRelationship>(e.OwnedRelationships, x => x.Name, "entity owned relation"));

            RuleForEach(e => e.Queries)
                .SetValidator(e => new DomainQueryValidator(e.Queries, e.Name));

            RuleForEach(e => e.Commands)
                .SetValidator(v => new DomainCommandValidator(v.Commands, v.Name));

            RuleForEach(p => p.Keys)
                .SetValidator(v => new EntityKeyValidator(v.Name, "entity keys"))
                .SetValidator(e => new UniquePropertyValidator<NoxSimpleTypeDefinition>(e.Keys,x=>x.Name, "entity key")); 

            RuleForEach(p => p.Keys!.Where(x => x.Type == NoxType.Nuid))
                .SetValidator(v => new NuidKeyValidator(v));

            RuleForEach(p => p.Attributes)
                .SetValidator(v => new SimpleTypeValidator($"an Attribute of entity '{v.Name}'", "entity attributes"))
                .SetValidator(e => new UniquePropertyValidator<NoxSimpleTypeDefinition>(e.Attributes, x => x.Name, "entity attribute"));

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
        }

        private bool MustHaveUniqueName(Entity toEvaluate, string name)
        {
            return _entities!.All(entity => entity.Equals(toEvaluate) || entity.Name != name);
        }
    }
}