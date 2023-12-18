//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class QueryToTableExecuteCompletedEvent: EtlExecuteCompletedEvent, INotification
{
    public QueryToTableExecuteCompletedEvent(EtlExecuteCompletedDto dto)
    {
        IntegrationName = "QueryToTable";
    }
}