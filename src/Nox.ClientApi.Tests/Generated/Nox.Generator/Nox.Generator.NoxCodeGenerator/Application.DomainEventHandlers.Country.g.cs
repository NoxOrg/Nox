// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

/// <summary>
/// Domain event handler for Country created event.
/// </summary>
internal partial class CountryCreatedDomainEventHandler : INotificationHandler<CountryCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    public CountryCreatedDomainEventHandler(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public async Task Handle(CountryCreated domainEvent, CancellationToken cancellationToken)
    {
        await RaiseCountryCreatedIntegrationEventAsync(domainEvent.Country);
    }
    
    private async Task RaiseCountryCreatedIntegrationEventAsync(Country entity)
    {
        var dto = entity.ToDto();
        var @event = new IntegrationEvents.CountryCreated(dto);
        await RaiseIntegrationEvent(@event); 
    }

    protected async Task RaiseIntegrationEvent(IIntegrationEvent @event)
        => await _outboxRepository.AddAsync(@event);
}