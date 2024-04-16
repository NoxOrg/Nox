// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class StoreUpdatedRaiseIntegrationEventDomainEventHandlerBase : INotificationHandler<StoreUpdated>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected StoreUpdatedRaiseIntegrationEventDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(StoreUpdated domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.Store.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.StoreUpdated(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class StoreUpdatedRaiseIntegrationEventDomainEventHandler : StoreUpdatedRaiseIntegrationEventDomainEventHandlerBase
{
    public StoreUpdatedRaiseIntegrationEventDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}