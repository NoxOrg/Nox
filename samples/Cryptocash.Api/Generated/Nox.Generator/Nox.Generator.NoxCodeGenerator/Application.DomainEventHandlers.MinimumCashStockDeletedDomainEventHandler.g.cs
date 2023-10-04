// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class MinimumCashStockDeletedDomainEventHandlerBase : INotificationHandler<MinimumCashStockDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected MinimumCashStockDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(MinimumCashStockDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class MinimumCashStockDeletedDomainEventHandler : MinimumCashStockDeletedDomainEventHandlerBase
{
    public MinimumCashStockDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}