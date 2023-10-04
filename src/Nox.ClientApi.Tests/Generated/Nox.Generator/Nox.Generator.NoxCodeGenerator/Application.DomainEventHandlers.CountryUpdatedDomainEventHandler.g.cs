// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class CountryUpdatedDomainEventHandlerBase : INotificationHandler<CountryUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected CountryUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CountryUpdated domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.Country.ToDto();
        var @event = new IntegrationEvents.CountryUpdated(dto);
        await RaiseIntegrationEventAsync(@event);
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class CountryUpdatedDomainEventHandler : CountryUpdatedDomainEventHandlerBase
{
    public CountryUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}