//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class ProcToTableExecuteCompletedEvent: EtlExecuteCompletedEvent, INotification
{
    public ProcToTableExecuteCompletedEvent(EtlExecuteCompletedDto dto)
    {
        IntegrationName = "ProcToTable";
    }
}