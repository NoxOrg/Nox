using MediatR;
using Nox.Integration.Abstractions;
using Nox.Integration.EtlEvents;

namespace Cryptocash.Integration.Integrations;

public class CountryQueryToCustomTableEtlRecordUpdatedEvent: NoxEtlRecordUpdatedEvent<INoxEtlEventPayload>, INotification
{
    public CountryQueryToCustomTableEtlRecordUpdatedEvent(CountryQueryToCustomTableRecordUpdatedPayload payload)
    {
        IntegrationName = "QueryToCustomTable";
    }
}