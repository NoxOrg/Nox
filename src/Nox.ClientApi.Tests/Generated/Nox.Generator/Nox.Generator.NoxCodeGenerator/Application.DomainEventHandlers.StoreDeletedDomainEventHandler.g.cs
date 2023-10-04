// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class StoreDeletedDomainEventHandlerBase : INotificationHandler<StoreDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected StoreDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(StoreDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class StoreDeletedDomainEventHandler : StoreDeletedDomainEventHandlerBase
{
    public StoreDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}