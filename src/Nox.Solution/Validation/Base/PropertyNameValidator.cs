using FluentValidation;
using Nox.Types;

namespace Nox.Solution.Validation
{
    internal class PropertyNameValidator : AbstractValidator<NoxSimpleTypeDefinition>
    {
        public PropertyNameValidator(string entityName, string objectType)
        {
            RuleFor(p => p.Name)
                .NotEqual(entityName)
                .WithMessage(m => string.Format(ValidationResources.NameSameAsEnclosingType, m.Name, entityName));
        }
    }
}