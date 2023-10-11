using FluentValidation;

namespace Nox.Solution.Validation.Events;

public class IntegrationEventValidator: AbstractValidator<IntegrationEvent>
{
    public IntegrationEventValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.ApplicationEventNameEmpty));

        RuleFor(c => c.Type)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.ApplicationEventTypeEmpty, m.Name));

        RuleFor(c => c.ObjectTypeOptions!)
            .SetValidator(v => new ObjectTypeOptionsValidator($"application event '{v.Name}'", "Application events"));
    }
}