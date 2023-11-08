using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationTargetDatabaseOptionsValidator: AbstractValidator<IntegrationTargetDatabaseOptions?>
{
    public IntegrationTargetDatabaseOptionsValidator(string integrationName, IntegrationTargetAdapterType adapterType)
    {
        RuleFor(opt => opt!.TableName)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetDatabaseOptionsTableNameEmpty, integrationName))
            .When(_ => adapterType == IntegrationTargetAdapterType.DatabaseTable);
        
        RuleFor(opt => opt!.StoredProcedure)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetDatabaseOptionsStoredProcEmpty, integrationName))
            .When(_ => adapterType == IntegrationTargetAdapterType.DatabaseTable);
        
        RuleFor(opt => opt!.SchemaName)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetDatabaseOptionsSchemaEmpty, integrationName));
    }
}