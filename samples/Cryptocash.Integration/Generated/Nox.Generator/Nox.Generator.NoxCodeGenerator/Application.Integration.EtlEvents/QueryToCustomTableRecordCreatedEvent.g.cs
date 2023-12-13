//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class QueryToCustomTableRecordCreatedEvent: EtlRecordCreatedEvent<IEtlEventDto>, INotification
{
    public QueryToCustomTableRecordCreatedEvent(QueryToCustomTableRecordCreatedDto dto)
    {
        IntegrationName = "QueryToCustomTable";
        SetDto(dto);
    }
}