using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationSourceFileOptionsValidator: AbstractValidator<IntegrationSourceFileOptions?>
{
    public IntegrationSourceFileOptionsValidator(string integrationName)
    {
        RuleFor(opt => opt!.Filename)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceFileOptionsFilenameEmpty, integrationName));
        
        RuleFor(p => p!.RecordAttributes)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.IntegrationSourceFileAttributesEmpty, integrationName));

        RuleForEach(p => p!.RecordAttributes)
            .SetValidator(v => new SimpleTypeValidator($"The Record Attributes of the source for integration '{integrationName}' has an attribute that", "file source record attributes"));
    }
}