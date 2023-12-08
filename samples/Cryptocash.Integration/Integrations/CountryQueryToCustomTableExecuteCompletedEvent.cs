using MediatR;
using Nox.Integration.EtlEvents;

namespace Cryptocash.Integration.Integrations;

public class CountryQueryToCustomTableExecuteCompletedEvent: NoxEtlExecuteCompletedEvent, INotification
{
    public CountryQueryToCustomTableExecuteCompletedEvent(NoxEtlExecuteCompletedPayload payload)
    {
        IntegrationName = "QueryToCustomTable";
    }
}