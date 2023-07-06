using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation
{
    internal class EntityRelationshipValidator: AbstractValidator<EntityRelationship>
    {
        private readonly IEnumerable<EntityRelationship>? _relationships;
        private readonly IEnumerable<Entity>? _entities;

        public EntityRelationshipValidator(string entityName, IEnumerable<EntityRelationship>? relationships, IEnumerable<Entity>? entities, bool bindToOther = true)
        {
            if (relationships == null) return;
            if (entities == null) return;
            _entities = entities;
            _relationships = relationships;
            
            RuleFor(er => er.Name)
                .NotEmpty()
                .WithMessage(er => string.Format(ValidationResources.EntityRelationshipNameEmpty, entityName));
            
            RuleFor(er => er.Name).Must(HaveUniqueName)
                .WithMessage(er => string.Format(ValidationResources.EntityRelationshipNameDuplicate, er.Name));
            
            RuleFor(er => er.Description)
                .NotEmpty()
                .WithMessage(er => string.Format(ValidationResources.EntityRelationshipDescriptionEmpty, er.Name, entityName));
            
            RuleFor(er => er.Relationship)
                .NotEmpty()
                .WithMessage(er => string.Format(ValidationResources.EntityRelationshipRelationshipEmpty, er.Name, entityName, EntityRelationshipType.ExactlyOne.ToNameList()));
            
            RuleFor(er => er.Entity)
                .NotEmpty()
                .WithMessage(er => string.Format(ValidationResources.EntityRelationshipEntityEmpty, er.Name, entityName));

            RuleFor(er => er.Entity!).Must(ReferenceExistingEntity)
                .WithMessage(er => string.Format(ValidationResources.EntityRelationshipEntityMissing, er.Name, entityName, er.Entity));

            if (bindToOther)
            {
                RuleFor(er => entityName).Must(HaveReverseRelationship)
                    .WithMessage(er => string.Format(ValidationResources.CorrespondingRelationshipMissing, er.Name, entityName, er.Entity));
            }

        }

        private bool HaveUniqueName(EntityRelationship toEvaluate, string name)
        {
            //Check names in this entity relationships
            return _relationships!.All(rel => rel.Equals(toEvaluate) || rel.Name != name);
        }

        private bool ReferenceExistingEntity(EntityRelationship toEvaluate, string otherEntity)
        {
           return _entities!.Any(e => e.Name == otherEntity);
        }

        private bool HaveReverseRelationship(EntityRelationship toEvaluate, string thisEntity)
        {
            var otherEntity = _entities?.FirstOrDefault(e => e.Name == toEvaluate.Entity);
            toEvaluate.Other.Entity = otherEntity!;

            var otherRelationship = toEvaluate.Other.Entity?.Relationships?.FirstOrDefault(e => e.Entity == thisEntity);
            toEvaluate.Other.EntityRelationship = otherRelationship!;

            return otherEntity is not null && otherRelationship is not null;
        }
    }
}