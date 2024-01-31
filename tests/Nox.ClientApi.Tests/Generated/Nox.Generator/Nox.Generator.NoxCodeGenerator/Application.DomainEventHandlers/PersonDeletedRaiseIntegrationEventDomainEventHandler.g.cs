// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class PersonDeletedRaiseIntegrationEventDomainEventHandlerBase : INotificationHandler<PersonDeleted>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected PersonDeletedRaiseIntegrationEventDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(PersonDeleted domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.Person.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.PersonDeleted(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class PersonDeletedRaiseIntegrationEventDomainEventHandler : PersonDeletedRaiseIntegrationEventDomainEventHandlerBase
{
    public PersonDeletedRaiseIntegrationEventDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}