//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions;
using Nox.Integration.EtlEvents;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToCustomTableRecordCreatedEvent: NoxEtlRecordCreatedEvent<INoxEtlEventPayload>, INotification
{
    public CountryQueryToCustomTableRecordCreatedEvent(QueryToCustomTableRecordCreatedPayload payload)
    {
        IntegrationName = "QueryToCustomTable";
        SetPayload(payload);
    }
}