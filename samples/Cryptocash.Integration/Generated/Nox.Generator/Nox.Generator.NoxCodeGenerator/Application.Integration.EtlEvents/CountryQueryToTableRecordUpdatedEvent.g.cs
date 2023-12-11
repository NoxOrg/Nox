//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToTableRecordUpdatedEvent: NoxEtlRecordUpdatedEvent<INoxEtlEventPayload>, INotification
{
    public CountryQueryToTableRecordUpdatedEvent(QueryToTableRecordUpdatedPayload payload)
    {
        IntegrationName = "QueryToTable";
    }
}