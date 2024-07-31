//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class JsonToTableRecordCreatedEvent: EtlRecordCreatedEvent<IEtlEventDto>, INotification
{
    public JsonToTableRecordCreatedEvent(JsonToTableRecordCreatedDto dto)
    {
        IntegrationName = "JsonToTable";
        SetDto(dto);
    }
}