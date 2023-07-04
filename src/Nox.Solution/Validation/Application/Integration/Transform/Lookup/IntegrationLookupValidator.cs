using FluentValidation;

namespace Nox.Solution.Validation
{
    public class IntegrationLookupValidator: AbstractValidator<IntegrationLookup>
    {
        internal IntegrationLookupValidator(string integrationName)
        {
            RuleFor(p => p.SourceColumn)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.IntegrationLookupSourceColumnEmpty, integrationName));

            RuleFor(p => p.Match)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.IntegrationLookupMatchEmpty, integrationName));

            RuleFor(p => p.Match!)
                .SetValidator(new IntegrationMatchValidator(integrationName));
            
            RuleFor(p => p.TargetAttribute)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.IntegrationLookupTargetAttributeEmpty, integrationName));
        }
    }
}