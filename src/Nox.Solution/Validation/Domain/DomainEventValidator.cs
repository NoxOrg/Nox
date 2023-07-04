using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Nox.Solution.Events;

namespace Nox.Solution.Validation;

public class DomainEventValidator: AbstractValidator<DomainEvent>
{
    private readonly IEnumerable<DomainEvent>? _domainEvents;
    private readonly IEnumerable<ApplicationEvent>? _appEvents;

    public DomainEventValidator(IEnumerable<DomainEvent>? domainEvents, IEnumerable<ApplicationEvent>? appEvents, string entityName)
    {
        if (domainEvents == null) return;
        _domainEvents = domainEvents;
        _appEvents = appEvents;

        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.DomainEventNameEmpty, entityName));
            
        RuleFor(c => c.Name).Must(HaveUniqueName)
            .WithMessage(m => string.Format(ValidationResources.DomainEventNameDuplicate, m.Name, entityName));

        RuleFor(c => c.Type)
            .NotEmpty()
            .WithMessage(m => string.Format(ValidationResources.DomainEventTypeEmpty, m.Name, entityName));

        RuleFor(c => c.ObjectTypeOptions!)
            .SetValidator(v => new ObjectTypeOptionsValidator($"domain event '{v.Name}' in entity '{entityName}'", "Domain events"));
    }
        
    private bool HaveUniqueName(DomainEvent toEvaluate, string name)
    {
        var domainEventResult = _domainEvents!.All(de => de.Equals(toEvaluate) || de.Name != name);
        if (domainEventResult == false || _appEvents == null || !_appEvents.Any()) return domainEventResult;
        return _appEvents.All(ae => ae.Name != name);
    }
}