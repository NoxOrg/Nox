using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationSourceMessageQueueOptionsValidator: AbstractValidator<IntegrationSourceMessageQueueOptions?>
{
    public IntegrationSourceMessageQueueOptionsValidator(string integrationName)
    {
        RuleFor(opt => opt!.SourceName)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceMsgQueueOptionsSourceEmpty, integrationName));
        
        RuleFor(p => p!.MessageAttributes)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.IntegrationSourceMessageAttributesEmpty, integrationName));

        RuleForEach(p => p!.MessageAttributes)
            .SetValidator(v => new SimpleTypeValidator($"The Message Attributes of the source for integration '{integrationName}' has an attribute that", "message source attributes"));
    }
}