//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToTableExecuteCompletedEvent: EtlExecuteCompletedEvent, INotification
{
    public CountryQueryToTableExecuteCompletedEvent(EtlExecuteCompletedDto dto)
    {
        IntegrationName = "QueryToTable";
    }
}