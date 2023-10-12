using FluentValidation;

namespace Nox.Solution.Validation;

internal class IntegrationTargetMessageQueueOptionsValidator: AbstractValidator<IntegrationTargetMessageQueueOptions?>
{
    public IntegrationTargetMessageQueueOptionsValidator(string integrationName)
    {
        RuleFor(opt => opt!.TargetName)
            .NotEmpty()
            .WithMessage(opt => string.Format(ValidationResources.IntegrationSourceMsgQueueOptionsSourceEmpty, integrationName));
        
        RuleFor(p => p!.MessageAttributes)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.IntegrationTargetMessageAttributesEmpty, integrationName));

        RuleForEach(p => p!.MessageAttributes)
            .SetValidator(v => new SimpleTypeValidator($"The Message Attributes of the target for integration '{integrationName}' has an attribute that", "message target attributes"));
    }
}