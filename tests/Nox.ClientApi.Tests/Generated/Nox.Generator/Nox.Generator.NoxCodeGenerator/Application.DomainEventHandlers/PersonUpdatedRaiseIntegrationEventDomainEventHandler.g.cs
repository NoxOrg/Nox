// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class PersonUpdatedRaiseIntegrationEventDomainEventHandlerBase : INotificationHandler<PersonUpdated>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected PersonUpdatedRaiseIntegrationEventDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(PersonUpdated domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.Person.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.PersonUpdated(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class PersonUpdatedRaiseIntegrationEventDomainEventHandler : PersonUpdatedRaiseIntegrationEventDomainEventHandlerBase
{
    public PersonUpdatedRaiseIntegrationEventDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}