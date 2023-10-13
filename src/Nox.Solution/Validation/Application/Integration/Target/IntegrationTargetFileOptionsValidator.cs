using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationTargetFileOptionsValidator: AbstractValidator<IntegrationTargetFileOptions?>
{
    public IntegrationTargetFileOptionsValidator(string integrationName)
    {
        RuleFor(opt => opt!.Filename)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceFileOptionsFilenameEmpty, integrationName));
        
        RuleFor(p => p!.RecordAttributes)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.IntegrationTargetFileAttributesEmpty, integrationName));

        RuleForEach(p => p!.RecordAttributes)
            .SetValidator(v => new SimpleTypeValidator($"The Record Attributes of the target for integration '{integrationName}' has an attribute that", "file target record attributes"));
    }
}