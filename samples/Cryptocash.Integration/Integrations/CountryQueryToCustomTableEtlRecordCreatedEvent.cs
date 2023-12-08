using MediatR;
using Nox.Integration.Abstractions;
using Nox.Integration.EtlEvents;

namespace Cryptocash.Integration.Integrations;

public class CountryQueryToCustomTableEtlRecordCreatedEvent: NoxEtlRecordCreatedEvent<INoxEtlEventPayload>, INotification
{
    public CountryQueryToCustomTableEtlRecordCreatedEvent(CountryQueryToCustomTableRecordCreatedPayload payload)
    {
        IntegrationName = "QueryToCustomTable";
        SetPayload(payload);
    }
}