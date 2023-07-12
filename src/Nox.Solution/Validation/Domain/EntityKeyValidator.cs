using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class EntityKeyValidator : SimpleTypeValidator
    {
        public EntityKeyValidator(string description, string objectType) : base(description, objectType)
        {
            RuleFor(p => p.IsRequired)
              .Equal(true)
              .WithMessage(m => string.Format(ValidationResources.EntityKeyIsRequired, description, m.Name));
        }
    }
}