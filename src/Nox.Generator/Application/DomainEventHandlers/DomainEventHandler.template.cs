// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.DomainEventHandlers;

{{ if entity.Persistence.Create.RaiseDomainEvents -}}
/// <summary>
/// Domain event handler for {{entity.Name}} created event.
/// </summary>
internal partial class {{entity.Name}}CreatedDomainEventHandler : INotificationHandler<{{entity.Name}}Created>
{
    private readonly IOutboxRepository _outboxRepository;

    public {{entity.Name}}CreatedDomainEventHandler(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public async Task Handle(CountryCreated domainEvent, CancellationToken cancellationToken)
    {      
{{- if entity.Persistence.Create.RaiseIntegrationEvents }}
        await Raise{{entity.Name}}CreatedIntegrationEventAsync(domainEvent.{{entity.Name}});
    }
    
    private async Task Raise{{entity.Name}}CreatedIntegrationEventAsync({{entity.Name}} entity)
    {
        var dto = entity.ToDto();
        var @event = new IntegrationEvents.{{entity.Name}}Created(dto);
        await RaiseIntegrationEvent(@event);
{{- end }} 
    }

    protected async Task RaiseIntegrationEvent(IIntegrationEvent @event)
        => await _outboxRepository.AddAsync(@event);
}
{{- end -}}