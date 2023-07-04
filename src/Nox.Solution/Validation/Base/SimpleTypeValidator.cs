using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class SimpleTypeValidator: AbstractValidator<NoxSimpleTypeDefinition>
    {
        public SimpleTypeValidator(string description, string objectType)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.SimpleTypeNameEmpty, description, objectType));
            
            RuleFor(p => p.Type)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.SimpleTypeNameEmpty, description, objectType));
        }
    }
}