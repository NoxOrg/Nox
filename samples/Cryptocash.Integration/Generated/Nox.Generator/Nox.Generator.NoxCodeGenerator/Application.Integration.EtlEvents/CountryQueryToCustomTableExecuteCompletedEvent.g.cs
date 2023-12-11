//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToCustomTableExecuteCompletedEvent: NoxEtlExecuteCompletedEvent, INotification
{
    public CountryQueryToCustomTableExecuteCompletedEvent(NoxEtlExecuteCompletedPayload payload)
    {
        IntegrationName = "QueryToCustomTable";
    }
}