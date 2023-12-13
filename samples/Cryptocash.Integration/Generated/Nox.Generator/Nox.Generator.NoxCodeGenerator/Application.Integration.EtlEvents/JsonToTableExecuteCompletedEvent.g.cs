//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class JsonToTableExecuteCompletedEvent: EtlExecuteCompletedEvent, INotification
{
    public JsonToTableExecuteCompletedEvent(EtlExecuteCompletedDto dto)
    {
        IntegrationName = "JsonToTable";
    }
}