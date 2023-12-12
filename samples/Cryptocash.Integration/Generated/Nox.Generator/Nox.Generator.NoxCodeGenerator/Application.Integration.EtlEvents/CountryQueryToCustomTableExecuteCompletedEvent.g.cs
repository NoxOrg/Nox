//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToCustomTableExecuteCompletedEvent: EtlExecuteCompletedEvent, INotification
{
    public CountryQueryToCustomTableExecuteCompletedEvent(EtlExecuteCompletedDto dto)
    {
        IntegrationName = "QueryToCustomTable";
    }
}