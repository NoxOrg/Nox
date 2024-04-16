// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class CountryUpdatedRaiseIntegrationEventDomainEventHandlerBase : INotificationHandler<CountryUpdated>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected CountryUpdatedRaiseIntegrationEventDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CountryUpdated domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.Country.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.CountryUpdated(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class CountryUpdatedRaiseIntegrationEventDomainEventHandler : CountryUpdatedRaiseIntegrationEventDomainEventHandlerBase
{
    public CountryUpdatedRaiseIntegrationEventDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}