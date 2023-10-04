// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class CountryTimeZoneUpdatedDomainEventHandlerBase : INotificationHandler<CountryTimeZoneUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected CountryTimeZoneUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CountryTimeZoneUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class CountryTimeZoneUpdatedDomainEventHandler : CountryTimeZoneUpdatedDomainEventHandlerBase
{
    public CountryTimeZoneUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}