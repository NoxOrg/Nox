using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution.Validation
{
    internal class EntityPersistenceValidator : AbstractValidator<EntityPersistence>
    {
        public EntityPersistenceValidator(string entityName, IEnumerable<Entity>? entities)
        {
            RuleFor(ep => ep.ApplyDefaults(entityName))
                .NotEqual(false)
                .WithMessage(e => string.Format(ValidationResources.EntityPersistenceDefaultsFalse, entityName));

            RuleFor(ep => ep.TableName)
                .NotEmpty()
                .WithMessage(ep => string.Format(ValidationResources.EntityPersistenceTableNameEmpty, entityName));

            RuleFor(ep => ep.IsAudited)
                .NotEqual(true)
                .When(ep => IsOwnedByAnyOtherEntity(entityName, entities))
                .WithMessage(ep => string.Format(ValidationResources.EntityOwnedCannotBeAuditable, entityName));
        }

        private static bool IsOwnedByAnyOtherEntity(string entityName, IEnumerable<Entity>? entities) 
            => entities?.Any(parentEntity => IsOwnedByParentEntity(entityName, parentEntity)) == true;

        private static bool IsOwnedByParentEntity(string ownedEntityName, Entity parentEntity)
            => parentEntity.OwnedRelationships?.Select(r => r.Entity)?.Contains(ownedEntityName) == true;
    }
}