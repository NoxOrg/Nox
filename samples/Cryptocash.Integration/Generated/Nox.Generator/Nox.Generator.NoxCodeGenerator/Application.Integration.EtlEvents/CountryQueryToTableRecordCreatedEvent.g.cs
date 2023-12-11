//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions;
using Nox.Integration.EtlEvents;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToTableRecordCreatedEvent: NoxEtlRecordCreatedEvent<INoxEtlEventPayload>, INotification
{
    public CountryQueryToTableRecordCreatedEvent(QueryToTableRecordCreatedPayload payload)
    {
        IntegrationName = "QueryToTable";
        SetPayload(payload);
    }
}