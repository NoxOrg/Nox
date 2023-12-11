//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToCustomTableRecordUpdatedEvent: NoxEtlRecordUpdatedEvent<INoxEtlEventPayload>, INotification
{
    public CountryQueryToCustomTableRecordUpdatedEvent(QueryToCustomTableRecordUpdatedPayload payload)
    {
        IntegrationName = "QueryToCustomTable";
    }
}