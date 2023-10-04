// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class MinimumCashStockUpdatedDomainEventHandlerBase : INotificationHandler<MinimumCashStockUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected MinimumCashStockUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(MinimumCashStockUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class MinimumCashStockUpdatedDomainEventHandler : MinimumCashStockUpdatedDomainEventHandlerBase
{
    public MinimumCashStockUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}