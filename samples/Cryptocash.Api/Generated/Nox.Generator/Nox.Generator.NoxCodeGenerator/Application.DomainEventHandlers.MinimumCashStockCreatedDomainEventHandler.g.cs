// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class MinimumCashStockCreatedDomainEventHandlerBase : INotificationHandler<MinimumCashStockCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected MinimumCashStockCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(MinimumCashStockCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class MinimumCashStockCreatedDomainEventHandler : MinimumCashStockCreatedDomainEventHandlerBase
{
    public MinimumCashStockCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}