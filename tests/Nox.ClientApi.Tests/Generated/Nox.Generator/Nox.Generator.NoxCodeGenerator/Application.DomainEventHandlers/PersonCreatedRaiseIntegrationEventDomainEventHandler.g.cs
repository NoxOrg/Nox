// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class PersonCreatedRaiseIntegrationEventDomainEventHandlerBase : INotificationHandler<PersonCreated>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected PersonCreatedRaiseIntegrationEventDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(PersonCreated domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.Person.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.PersonCreated(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class PersonCreatedRaiseIntegrationEventDomainEventHandler : PersonCreatedRaiseIntegrationEventDomainEventHandlerBase
{
    public PersonCreatedRaiseIntegrationEventDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}