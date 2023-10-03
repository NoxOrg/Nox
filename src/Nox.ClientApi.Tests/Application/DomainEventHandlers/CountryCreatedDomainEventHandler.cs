using ClientApi.Application.Dto;
using ClientApi.Domain;

namespace ClientApi.Application.DomainEventHandlers;

internal partial class CountryCreatedDomainEventHandler
{
    public override async Task Handle(CountryCreated domainEvent, CancellationToken cancellationToken)
    {
        if (domainEvent.Country.Population?.Value > 100_000_000)
        {
            await RaiseIntegrationEventAsync(domainEvent.Country);
        }
    }

    private static async Task RaiseIntegrationEventAsync(Country country)
    {
        var @event = CreateIntegrationEvent(country);
        await RaiseIntegrationEventAsync(@event);
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
