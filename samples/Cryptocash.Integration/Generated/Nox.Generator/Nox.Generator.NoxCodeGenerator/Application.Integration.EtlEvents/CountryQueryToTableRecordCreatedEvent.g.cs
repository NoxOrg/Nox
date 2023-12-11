//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToTableRecordCreatedEvent: NoxEtlRecordCreatedEvent<INoxEtlEventPayload>, INotification
{
    public CountryQueryToTableRecordCreatedEvent(QueryToTableRecordCreatedPayload payload)
    {
        IntegrationName = "QueryToTable";
        SetPayload(payload);
    }
}