//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class QueryToCustomTableExecuteCompletedEvent: EtlExecuteCompletedEvent, INotification
{
    public QueryToCustomTableExecuteCompletedEvent(EtlExecuteCompletedDto dto)
    {
        IntegrationName = "QueryToCustomTable";
    }
}