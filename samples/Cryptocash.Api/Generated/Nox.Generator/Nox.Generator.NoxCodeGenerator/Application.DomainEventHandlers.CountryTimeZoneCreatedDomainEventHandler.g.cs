// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class CountryTimeZoneCreatedDomainEventHandlerBase : INotificationHandler<CountryTimeZoneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected CountryTimeZoneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CountryTimeZoneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class CountryTimeZoneCreatedDomainEventHandler : CountryTimeZoneCreatedDomainEventHandlerBase
{
    public CountryTimeZoneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}