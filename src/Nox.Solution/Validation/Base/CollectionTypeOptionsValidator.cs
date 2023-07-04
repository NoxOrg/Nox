using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class CollectionTypeOptionsValidator: AbstractValidator<ArrayTypeOptions>
    {
        public CollectionTypeOptionsValidator(string description, string objectType)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.CollectionTypeOptionsNameEmpty, description));
            
            RuleFor(p => p.Type)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.CollectionTypeOptionsTypeEmpty, description));

            RuleFor(p => p.ObjectTypeOptions!)
                .SetValidator(v => new ObjectTypeOptionsValidator(description, objectType));
        }
    }
}