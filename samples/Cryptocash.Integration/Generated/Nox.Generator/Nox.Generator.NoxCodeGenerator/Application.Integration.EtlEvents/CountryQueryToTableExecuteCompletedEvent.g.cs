//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToTableExecuteCompletedEvent: NoxEtlExecuteCompletedEvent, INotification
{
    public CountryQueryToTableExecuteCompletedEvent(NoxEtlExecuteCompletedPayload payload)
    {
        IntegrationName = "QueryToTable";
    }
}