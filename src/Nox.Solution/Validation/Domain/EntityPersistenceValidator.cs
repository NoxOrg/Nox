using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class EntityPersistenceValidator : AbstractValidator<EntityPersistence>
    {
        public EntityPersistenceValidator(Entity entity)
        {
            RuleFor(ep => ep.ApplyDefaults(entity.Name))
                .NotEqual(false)
                .WithMessage(e => string.Format(ValidationResources.EntityPersistenceDefaultsFalse, entity.Name));

            RuleFor(ep => ep.TableName)
                .NotEmpty()
                .WithMessage(ep => string.Format(ValidationResources.EntityPersistenceTableNameEmpty, entity.Name));

            RuleFor(ep => ep.IsAudited)
                .NotEqual(true)
                .When(ep => entity.IsOwnedEntity)
                .WithMessage(ep => string.Format(ValidationResources.EntityOwnedCannotBeAuditable, entity.Name));
        }
    }
}