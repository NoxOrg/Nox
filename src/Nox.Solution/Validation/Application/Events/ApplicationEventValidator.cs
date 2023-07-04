using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Nox.Solution.Events;

namespace Nox.Solution.Validation.Events;

public class ApplicationEventValidator: AbstractValidator<ApplicationEvent>
{
    private readonly IEnumerable<ApplicationEvent>? _appEvents;
    private readonly IEnumerable<DomainEvent>? _domainEvents;

    public ApplicationEventValidator(IEnumerable<ApplicationEvent>? appEvents, IEnumerable<DomainEvent>? domainEvents)
    {
        if (appEvents == null) return;
        _appEvents = appEvents;
        _domainEvents = domainEvents;

        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.ApplicationEventNameEmpty));
            
        RuleFor(c => c.Name).Must(HaveUniqueName)
            .WithMessage(m => string.Format(ValidationResources.ApplicationEventNameDuplicate, m.Name));

        RuleFor(c => c.Type)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.ApplicationEventTypeEmpty, m.Name));

        RuleFor(c => c.ObjectTypeOptions!)
            .SetValidator(v => new ObjectTypeOptionsValidator($"application event '{v.Name}'", "Application events"));
    }
        
    private bool HaveUniqueName(ApplicationEvent toEvaluate, string name)
    {
        var appEventResult = _appEvents!.All(ae => ae.Equals(toEvaluate) || ae.Name != name);
        if (appEventResult == false || _domainEvents == null || !_domainEvents.Any()) return appEventResult;
        return _domainEvents.All(de => de.Name != name);
    }
}