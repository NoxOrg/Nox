//Generated

#nullable enable

using MediatR;
using Nox.Integration.EtlEvents;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToCustomTableExecuteCompletedEvent: NoxEtlExecuteCompletedEvent, INotification
{
    public CountryQueryToCustomTableExecuteCompletedEvent(NoxEtlExecuteCompletedPayload payload)
    {
        IntegrationName = "QueryToCustomTable";
    }
}