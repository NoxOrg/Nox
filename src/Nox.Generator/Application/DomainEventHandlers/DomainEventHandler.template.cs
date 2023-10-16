// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.DomainEventHandlers;

internal abstract class {{className}}Base : INotificationHandler<{{entity.Name}}{{operation}}>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected {{className}}Base(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle({{entity.Name}}{{operation}} domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.{{entity.Name}}.ToDto();
        var @event = new {{codeGeneratorState.ApplicationNameSpace}}.IntegrationEvents.{{entity.Name}}{{operation}}(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class {{className}} : {{className}}Base
{
    public {{className}}(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}