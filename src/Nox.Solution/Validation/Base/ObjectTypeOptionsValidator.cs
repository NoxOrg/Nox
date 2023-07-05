using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class ObjectTypeOptionsValidator: AbstractValidator<ObjectTypeOptions>
    {
        public ObjectTypeOptionsValidator(string description, string objectType)
        {
            RuleFor(p => p.Attributes)
                .NotEmpty()
                .WithMessage(m => string.Format(ValidationResources.ObjectTypeOptionsAttributesEmpty, description, objectType));
            
            
        }
    }
}