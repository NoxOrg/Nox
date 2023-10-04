// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class PaymentProviderUpdatedDomainEventHandlerBase : INotificationHandler<PaymentProviderUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected PaymentProviderUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(PaymentProviderUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class PaymentProviderUpdatedDomainEventHandler : PaymentProviderUpdatedDomainEventHandlerBase
{
    public PaymentProviderUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}