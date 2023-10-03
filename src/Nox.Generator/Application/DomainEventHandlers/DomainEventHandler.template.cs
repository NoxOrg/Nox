// Generated

#nullable enable

using System.Threading.Tasks;
using MediatR;
using Nox.Application;
using Nox.Messaging;

using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.DomainEventHandlers;

{{ if entity.Persistence.Create.RaiseDomainEvents -}}

internal abstract class {{entity.Name}}DomainEventHandlerBase<TEvent> : INotificationHandler<TEvent>
    where TEvent : INotification
{
    private readonly IOutboxRepository _outboxRepository;

    protected {{entity.Name}}DomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public abstract Task Handle(TEvent domainEvent, CancellationToken cancellationToken);

    protected async Task RaiseIntegrationEventAsync(IIntegrationEvent @event)
        => await _outboxRepository.AddAsync(@event);
}

internal partial class {{entity.Name}}CreatedDomainEventHandler : {{entity.Name}}DomainEventHandlerBase<{{entity.Name}}Created>
{
    public {{entity.Name}}CreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }

    public override async Task Handle({{entity.Name}}Created domainEvent, CancellationToken cancellationToken)
    {      
{{ if entity.Persistence.Create.RaiseIntegrationEvents -}}
        await Raise{{entity.Name}}CreatedIntegrationEventAsync(domainEvent.{{entity.Name}});
    }
    
    private static async Task Raise{{entity.Name}}CreatedIntegrationEventAsync({{entity.Name}} entity)
    {
        var dto = entity.ToDto();
        var @event = new IntegrationEvents.{{entity.Name}}Created(dto);
        await RaiseIntegrationEventAsync(@event);
    }
{{- end -}}
    }
}
{{- end -}}