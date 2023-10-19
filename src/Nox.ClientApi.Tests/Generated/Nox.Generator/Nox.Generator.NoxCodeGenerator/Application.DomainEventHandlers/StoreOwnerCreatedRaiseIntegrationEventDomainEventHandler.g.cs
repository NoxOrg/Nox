// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class StoreOwnerCreatedRaiseIntegrationEventDomainEventHandlerBase : INotificationHandler<StoreOwnerCreated>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected StoreOwnerCreatedRaiseIntegrationEventDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(StoreOwnerCreated domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.StoreOwner.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.StoreOwnerCreated(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class StoreOwnerCreatedRaiseIntegrationEventDomainEventHandler : StoreOwnerCreatedRaiseIntegrationEventDomainEventHandlerBase
{
    public StoreOwnerCreatedRaiseIntegrationEventDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}