using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationTargetDatabaseOptionsValidator: AbstractValidator<IntegrationTargetDatabaseOptions?>
{
    public IntegrationTargetDatabaseOptionsValidator(string integrationName)
    {
        RuleFor(opt => opt!.StoredProcedure)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceDatabaseOptionsQueryEmpty, integrationName));
    }
}