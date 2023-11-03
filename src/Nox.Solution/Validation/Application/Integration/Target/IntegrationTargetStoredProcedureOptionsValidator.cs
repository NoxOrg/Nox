using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationTargetStoredProcedureOptionsValidator: AbstractValidator<IntegrationTargetStoredProcedureOptions?>
{
    public IntegrationTargetStoredProcedureOptionsValidator(string integrationName)
    {
        RuleFor(opt => opt!.StoredProcedure)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetStoredProcOptionsNameEmpty, integrationName));
        
        RuleFor(opt => opt!.SchemaName)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetStoredProcOptionsSchemaEmpty, integrationName));
    }
}