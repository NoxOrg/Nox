// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.DomainEventHandlers;

{{ if entity.Persistence.Create.RaiseDomainEvents -}}

internal abstract class {{entity.Name}}CreatedDomainEventHandlerBase : INotificationHandler<{{entity.Name}}Created>
{
    private readonly IOutboxRepository _outboxRepository;

    protected {{entity.Name}}CreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle({{entity.Name}}Created domainEvent, CancellationToken cancellationToken)
    {
{{- if entity.Persistence.Create.RaiseIntegrationEvents }}
        var dto = domainEvent.{{entity.Name}}.ToDto();
        var @event = new IntegrationEvents.{{entity.Name}}Created(dto);
        await RaiseIntegrationEventAsync(@event);
{{- else }}
        await Task.CompletedTask;
{{- end }}
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class {{entity.Name}}CreatedDomainEventHandler : {{entity.Name}}CreatedDomainEventHandlerBase
{
    public {{entity.Name}}CreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}
{{- end -}}