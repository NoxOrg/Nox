using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationSourceFileOptionsValidator: AbstractValidator<IntegrationSourceFileOptions?>
{
    public IntegrationSourceFileOptionsValidator(string integrationName)
    {
        RuleFor(opt => opt!.Filename)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceFileOptionsFilenameEmpty, integrationName));

        RuleFor(opt => opt!.MinimumExpectedRecords)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceFileOptionsMinExptectedRecordsInvalid, integrationName));
    }
}