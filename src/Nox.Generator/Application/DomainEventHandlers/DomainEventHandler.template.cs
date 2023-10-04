// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.DomainEventHandlers;

internal abstract class {{className}}Base : INotificationHandler<{{entity.Name}}{{crudOperation}}>
{
    private readonly IOutboxRepository _outboxRepository;

    protected {{className}}Base(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle({{entity.Name}}{{crudOperation}} domainEvent, CancellationToken cancellationToken)
    {
{{- if entity.Persistence.Create.RaiseIntegrationEvents }}
        var dto = domainEvent.{{entity.Name}}.ToDto();
        var @event = new IntegrationEvents.{{entity.Name}}{{crudOperation}}(dto);
        await RaiseIntegrationEventAsync(@event);
{{- else }}
        await Task.CompletedTask;
{{- end }}
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class {{className}} : {{className}}Base
{
    public {{className}}(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}