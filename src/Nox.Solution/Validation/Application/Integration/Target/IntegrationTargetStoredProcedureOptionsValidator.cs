using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationTargetStoredProcedureOptionsValidator: AbstractValidator<IntegrationTargetStoredProcedureOptions?>
{
    public IntegrationTargetStoredProcedureOptionsValidator(string integrationName, IntegrationTargetAdapterType adapterType, DataConnectionProvider provider)
    {
        RuleFor(opt => opt!.ApplyDefaults(provider))
            .NotEqual(false)
            .WithMessage(e => string.Format(ValidationResources.IntegrationTargetStoredProcedureOptionsDefaultsFalse, integrationName));
        
        RuleFor(opt => opt!.StoredProcedure)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetStoredProcedureOptionsStoredProcEmpty, integrationName))
            .When(_ => adapterType == IntegrationTargetAdapterType.StoredProcedure);
        
        RuleFor(opt => opt!.SchemaName)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetStoredProcedureOptionsSchemaEmpty, integrationName));
    }
}