//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class JsonToTableRecordUpdatedEvent: EtlRecordUpdatedEvent<IEtlEventDto>, INotification
{
    public JsonToTableRecordUpdatedEvent(JsonToTableRecordUpdatedDto dto)
    {
        IntegrationName = "JsonToTable";
        SetDto(dto);
    }
}