using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationSourceDatabaseOptionsValidator: AbstractValidator<IntegrationSourceDatabaseOptions?>
{
    public IntegrationSourceDatabaseOptionsValidator(string integrationName)
    {
        RuleFor(opt => opt!.Query)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceDatabaseOptionsQueryEmpty, integrationName));

        RuleFor(opt => opt!.MinimumExpectedRecords)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceDatabaseOptionsMinExptectedRecordsInvalid, integrationName));

    }
}