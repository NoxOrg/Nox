//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class ProcToTableRecordUpdatedEvent: EtlRecordUpdatedEvent<IEtlEventDto>, INotification
{
    public ProcToTableRecordUpdatedEvent(ProcToTableRecordUpdatedDto dto)
    {
        IntegrationName = "ProcToTable";
        SetDto(dto);
    }
}