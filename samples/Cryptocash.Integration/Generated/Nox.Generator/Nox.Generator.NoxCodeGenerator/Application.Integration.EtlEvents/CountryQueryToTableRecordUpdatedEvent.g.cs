//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToTableRecordUpdatedEvent: EtlRecordUpdatedEvent<IEtlEventDto>, INotification
{
    public CountryQueryToTableRecordUpdatedEvent(QueryToTableRecordUpdatedDto dto)
    {
        IntegrationName = "QueryToTable";
    }
}