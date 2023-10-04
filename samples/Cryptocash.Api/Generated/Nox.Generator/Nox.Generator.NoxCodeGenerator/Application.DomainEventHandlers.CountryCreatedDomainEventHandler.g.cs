// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class CountryCreatedDomainEventHandlerBase : INotificationHandler<CountryCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected CountryCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CountryCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class CountryCreatedDomainEventHandler : CountryCreatedDomainEventHandlerBase
{
    public CountryCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}