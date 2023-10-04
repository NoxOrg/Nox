// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class CashStockOrderDeletedDomainEventHandlerBase : INotificationHandler<CashStockOrderDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected CashStockOrderDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CashStockOrderDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class CashStockOrderDeletedDomainEventHandler : CashStockOrderDeletedDomainEventHandlerBase
{
    public CashStockOrderDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}