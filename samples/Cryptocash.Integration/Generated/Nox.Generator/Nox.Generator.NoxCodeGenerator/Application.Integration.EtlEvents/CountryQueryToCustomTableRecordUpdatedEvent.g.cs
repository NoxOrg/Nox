//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToCustomTableRecordUpdatedEvent: EtlRecordUpdatedEvent<INoxEtlEventDto>, INotification
{
    public CountryQueryToCustomTableRecordUpdatedEvent(QueryToCustomTableRecordUpdatedDto dto)
    {
        IntegrationName = "QueryToCustomTable";
    }
}