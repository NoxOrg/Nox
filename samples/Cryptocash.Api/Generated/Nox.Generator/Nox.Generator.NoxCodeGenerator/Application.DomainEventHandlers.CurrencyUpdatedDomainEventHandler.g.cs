// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class CurrencyUpdatedDomainEventHandlerBase : INotificationHandler<CurrencyUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected CurrencyUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CurrencyUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class CurrencyUpdatedDomainEventHandler : CurrencyUpdatedDomainEventHandlerBase
{
    public CurrencyUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}