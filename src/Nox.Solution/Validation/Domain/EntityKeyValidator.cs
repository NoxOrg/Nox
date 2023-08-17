using FluentValidation;
using Nox.Types.Extensions;

namespace Nox.Solution.Validation
{
    internal class EntityKeyValidator : SimpleTypeValidator
    {
        public EntityKeyValidator(string description, string objectType) : base(description, objectType)
        {
            RuleFor(p => p.IsRequired)
              .Equal(true)
              .WithMessage(m => string.Format(ValidationResources.EntityKeyIsRequired, description, m.Name));

            // Do not accept compound with exception to Entity
            RuleFor(p => p.Type)
                .Must(x => !x.IsCompoundType() || x == Types.NoxType.Entity)
                .WithMessage(m => string.Format(ValidationResources.EntityKeyShouldNotBeCompoundType, description, m.Name));
        }
    }
}