using FluentValidation;

namespace Nox.Solution.Validation
{
    internal class IntegrationMappingValidator: AbstractValidator<IntegrationMapping>
    {
        public IntegrationMappingValidator(string integrationName)
        {
            RuleFor(p => p.SourceColumn)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.IntegrationMappingSourceColumnMissing, integrationName));

            RuleFor(p => p.TargetAttribute)
                .NotEmpty()
                .WithMessage(string.Format(ValidationResources.IntegrationMappingTargetAttributeMissing, integrationName));
        }
    }
}