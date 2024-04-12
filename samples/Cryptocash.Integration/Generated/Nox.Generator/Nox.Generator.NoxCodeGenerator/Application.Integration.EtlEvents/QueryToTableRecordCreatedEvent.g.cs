//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class QueryToTableRecordCreatedEvent: EtlRecordCreatedEvent<IEtlEventDto>, INotification
{
    public QueryToTableRecordCreatedEvent(QueryToTableRecordCreatedDto dto)
    {
        IntegrationName = "QueryToTable";
        SetDto(dto);
    }
}