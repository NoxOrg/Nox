using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal partial class CountryUpdatedDomainEventHandler
{
    public override async Task Handle(CountryUpdated domainEvent, CancellationToken cancellationToken)
    {
        await base.Handle(domainEvent, cancellationToken);

        if (domainEvent.Country.Population?.Value > 100_000_000)
        {
            var @event = CreateIntegrationEvent(domainEvent.Country);
            await RaiseIntegrationEventAsync(@event);
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