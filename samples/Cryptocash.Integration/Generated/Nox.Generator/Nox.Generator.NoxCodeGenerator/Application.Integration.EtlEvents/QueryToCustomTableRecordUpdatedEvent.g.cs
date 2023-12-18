//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class QueryToCustomTableRecordUpdatedEvent: EtlRecordUpdatedEvent<IEtlEventDto>, INotification
{
    public QueryToCustomTableRecordUpdatedEvent(QueryToCustomTableRecordUpdatedDto dto)
    {
        IntegrationName = "QueryToCustomTable";
        SetDto(dto);
    }
}