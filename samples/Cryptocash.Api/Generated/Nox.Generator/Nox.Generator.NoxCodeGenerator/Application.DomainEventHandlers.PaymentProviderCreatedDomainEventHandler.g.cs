// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class PaymentProviderCreatedDomainEventHandlerBase : INotificationHandler<PaymentProviderCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected PaymentProviderCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(PaymentProviderCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class PaymentProviderCreatedDomainEventHandler : PaymentProviderCreatedDomainEventHandlerBase
{
    public PaymentProviderCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}