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

        public EntityRelationshipValidator(string entityName, IEnumerable<Entity>? entities, bool bindToOtherRelationship = true)
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

            if (bindToOtherRelationship)
            {
                RuleFor(er => entityName).Must(HaveReverseRelationship)
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

        private bool HaveReverseRelationship(EntityRelationship toEvaluate, string thisEntity)
        {
            var otherRelationship = toEvaluate.Related.Entity?.Relationships?.FirstOrDefault(e => e.Entity == thisEntity);
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