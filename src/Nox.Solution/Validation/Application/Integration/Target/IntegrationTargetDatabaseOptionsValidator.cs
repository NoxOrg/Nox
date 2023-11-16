using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationTargetDatabaseOptionsValidator: AbstractValidator<IntegrationTargetDatabaseOptions?>
{
    public IntegrationTargetDatabaseOptionsValidator(string integrationName, IntegrationTargetAdapterType adapterType, DataConnectionProvider provider)
    {
        RuleFor(opt => opt!.ApplyDefaults(provider))
            .NotEqual(false)
            .WithMessage(e => string.Format(ValidationResources.IntegrationTargetDatabaseOptionsDefaultsFalse, integrationName));

        RuleFor(opt => opt!.TableName)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetDatabaseOptionsTableNameEmpty, integrationName))
            .When(_ => adapterType == IntegrationTargetAdapterType.DatabaseTable);
        
        RuleFor(opt => opt!.StoredProcedure)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetDatabaseOptionsStoredProcEmpty, integrationName))
            .When(_ => adapterType == IntegrationTargetAdapterType.StoredProcedure);
        
        RuleFor(opt => opt!.SchemaName)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetDatabaseOptionsSchemaEmpty, integrationName));
    }
}