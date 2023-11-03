using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationTargetTableOptionsValidator: AbstractValidator<IntegrationTargetTableOptions?>
{
    public IntegrationTargetTableOptionsValidator(string integrationName)
    {
        RuleFor(opt => opt!.TableName)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetTableOptionsNameEmpty, integrationName));
        
        RuleFor(opt => opt!.SchemaName)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationTargetTableOptionsSchemaEmpty, integrationName));
    }
}