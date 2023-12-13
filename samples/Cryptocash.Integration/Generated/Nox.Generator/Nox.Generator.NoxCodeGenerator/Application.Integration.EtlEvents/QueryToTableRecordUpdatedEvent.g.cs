//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class QueryToTableRecordUpdatedEvent: EtlRecordUpdatedEvent<IEtlEventDto>, INotification
{
    public QueryToTableRecordUpdatedEvent(QueryToTableRecordUpdatedDto dto)
    {
        IntegrationName = "QueryToTable";
        SetDto(dto);
    }
}