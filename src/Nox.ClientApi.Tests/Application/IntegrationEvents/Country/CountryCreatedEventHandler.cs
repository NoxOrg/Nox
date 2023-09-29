using ClientApi.Application.Dto;
using ClientApi.Application.IntegrationEvents;
using ClientApi.Domain;
using MediatR;
using Nox.Messaging;

namespace ClientApi.Application.IntegrationEvents.Country;

internal class CountryCreatedEventHandler : INotificationHandler<CountryCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    public CountryCreatedEventHandler(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public async Task Handle(CountryCreated domainEvent, CancellationToken cancellationToken)
    {
        var country = domainEvent.Country;

        if (country.Population?.Value > 100_000_000)
        {
            await RaiseIntegrationEventAsync(country);
        }
    }

    private async Task RaiseIntegrationEventAsync(Domain.Country country)
    {
        var integrationEvent = CreateIntegrationEvent(country);
        await _outboxRepository.AddAsync(integrationEvent);
    }

    private static CountryPopulationHigherThan100M CreateIntegrationEvent(Domain.Country? country)
        => new()
        {
            Name = country?.Name?.Value,
            Population = (int?)country?.Population?.Value,
            CountryDebt = country?.CountryDebt is not null
                ? new MoneyDto(country.CountryDebt!.Amount, country.CountryDebt!.CurrencyCode)
                : null
        };
}
