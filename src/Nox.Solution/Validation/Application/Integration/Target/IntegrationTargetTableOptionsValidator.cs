using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationTargetTableOptionsValidator: AbstractValidator<IntegrationTargetTableOptions?>
{
    public IntegrationTargetTableOptionsValidator(string integrationName, IntegrationTargetAdapterType adapterType, DataConnectionProvider provider)
    {
        RuleFor(opt => opt!.ApplyDefaults(provider))
            .NotEqual(false)
            .WithMessage(e => string.Format(ValidationResources.IntegrationTargetTableOptionsDefaultsFalse, integrationName));

        RuleFor(opt => opt!.TableName)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetTableOptionsTableNameEmpty, integrationName))
            .When(_ => adapterType == IntegrationTargetAdapterType.DatabaseTable);
        
        RuleFor(opt => opt!.SchemaName)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetTableOptionsSchemaEmpty, integrationName));
    }
}