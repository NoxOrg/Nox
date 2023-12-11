//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions;
using Nox.Integration.EtlEvents;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToCustomTableRecordUpdatedEvent: NoxEtlRecordUpdatedEvent<INoxEtlEventPayload>, INotification
{
    public CountryQueryToCustomTableRecordUpdatedEvent(QueryToCustomTableRecordUpdatedPayload payload)
    {
        IntegrationName = "QueryToCustomTable";
    }
}