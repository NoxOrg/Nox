using System.Collections.Generic;
using FluentValidation;
using Nox.Solution.Extensions;

namespace Nox.Solution.Validation;

internal class EventSourceServerValidator: AbstractValidator<EventSourceServer>
{
    public EventSourceServerValidator(IEnumerable<ServerBase>? servers)
    {
        Include(new ServerBaseValidator("the infrastructure, persistence, event source server", servers));
        RuleFor(p => p.Provider)
            .NotNull()
            .WithMessage(p => string.Format(ValidationResources.EventSourceServerProviderEmpty, p.Name, EventSourceServerProvider.EventStoreDb.ToNameList()));
    }
}