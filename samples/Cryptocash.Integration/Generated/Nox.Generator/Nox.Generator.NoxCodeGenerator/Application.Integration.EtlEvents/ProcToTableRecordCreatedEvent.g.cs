//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class ProcToTableRecordCreatedEvent: EtlRecordCreatedEvent<IEtlEventDto>, INotification
{
    public ProcToTableRecordCreatedEvent(ProcToTableRecordCreatedDto dto)
    {
        IntegrationName = "ProcToTable";
        SetDto(dto);
    }
}