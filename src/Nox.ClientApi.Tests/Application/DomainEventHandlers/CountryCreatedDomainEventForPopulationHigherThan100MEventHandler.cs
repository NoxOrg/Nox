using ClientApi.Domain;
using ClientApi.Application.Dto;
using MediatR;
using Nox.Infrastructure.Messaging;

namespace ClientApi.Application.DomainEventHandlers;

internal class CountryCreatedDomainEventForPopulationHigherThan100MEventHandler : INotificationHandler<ClientApi.Domain.CountryCreated>
{
    protected readonly IOutboxRepository _outboxRepository;

    public CountryCreatedDomainEventForPopulationHigherThan100MEventHandler(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public async Task Handle(ClientApi.Domain.CountryCreated domainEvent, CancellationToken cancellationToken)
    {
        if (domainEvent.Country.Population?.Value > 100_000_000)
        {
            var @event = CreateIntegrationEvent(domainEvent.Country);
            await _outboxRepository.AddAsync(@event);
        }
    }
    private static IntegrationEvents.CountryPopulationHigherThan100M CreateIntegrationEvent(Country? country)
      => new()
      {
          Name = country?.Name?.Value,
          Population = (int?)country?.Population?.Value,
          CountryDebt = country?.CountryDebt is not null
              ? new MoneyDto(country.CountryDebt!.Amount, country.CountryDebt!.CurrencyCode)
              : null
      };
}