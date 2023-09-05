using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation
{
    internal class EntityRelationshipValidator: AbstractValidator<EntityRelationship>
    {
        private readonly IEnumerable<Entity>? _entities;

        public EntityRelationshipValidator(string entityName, IEnumerable<Entity>? entities, bool requiresCorrespondingRelationship = true)
        {
            if (entities == null) return;
            _entities = entities;
            
            RuleFor(er => er.Name)
                .NotEmpty()
                .WithMessage(er => string.Format(ValidationResources.EntityRelationshipNameEmpty, entityName));
                        
            RuleFor(er => er.Description)
                .NotEmpty()
                .WithMessage(er => string.Format(ValidationResources.EntityRelationshipDescriptionEmpty, er.Name, entityName));

            RuleFor(er => er.Entity)
                .NotEmpty()
                .WithMessage(er => string.Format(ValidationResources.EntityRelationshipEntityEmpty, er.Name, entityName));

            RuleFor(er => er.Entity!).Must(ReferenceExistingEntity)
                .WithMessage(er => string.Format(ValidationResources.EntityRelationshipEntityMissing, er.Name, entityName, er.Entity));

            if (requiresCorrespondingRelationship)
            {
                RuleFor(er => entityName).Must((x, y) => HaveReverseRelationship(x,  _entities.First(x => x.Name.Equals(y))))
                    .WithMessage(er => string.Format(ValidationResources.CorrespondingRelationshipMissing, er.Name, entityName, er.Entity));
            }
            else
            {
                RuleFor(er => entityName).Must(HaveOneParentOnly)
                    .WithMessage(er => string.Format(ValidationResources.EntityOwnedRelationshipEntityUsedMultipleTimes, er.Name, entityName, er.Entity));
            }

        }

        private bool ReferenceExistingEntity(EntityRelationship toEvaluate, string otherEntityName)
        {
            var otherEntity = _entities?.FirstOrDefault(e => e.Name == otherEntityName);
            toEvaluate.Related.Entity = otherEntity!;
            return otherEntity is not null;
        }

        /// <summary>
        /// Match related relationship by file order
        /// </summary>
        private bool HaveReverseRelationship(EntityRelationship toEvaluate, Entity currentEntity)
        {
            var toEntityName = toEvaluate.Related.Entity.Name;
            var currentEntityRelationships = currentEntity
                .Relationships!
                .Where(x => x.Entity == toEntityName)
                .ToList();
            
            var currentRelationshipIndex = currentEntityRelationships.IndexOf(toEvaluate);

            var otherRelationship = toEvaluate.Related.Entity?.Relationships?
                .Where(e => e.Entity == currentEntity.Name)
                .Skip(currentRelationshipIndex)
                .FirstOrDefault();
            toEvaluate.Related.EntityRelationship = otherRelationship!;
            return otherRelationship is not null;
        }

        private bool HaveOneParentOnly(EntityRelationship toEvaluate, string parentName)
        {
            var otherParents = _entities?.FirstOrDefault(e => 
                e.Name != parentName &&
                e.OwnedRelationships?.Any(o => o.Entity.Equals(toEvaluate.Entity)) == true
                );

            return otherParents is null;
        }
    }
}