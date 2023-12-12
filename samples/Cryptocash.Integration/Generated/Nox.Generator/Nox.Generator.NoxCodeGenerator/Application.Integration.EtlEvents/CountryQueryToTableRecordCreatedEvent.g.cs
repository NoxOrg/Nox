//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToTableRecordCreatedEvent: EtlRecordCreatedEvent<IEtlEventDto>, INotification
{
    public CountryQueryToTableRecordCreatedEvent(QueryToTableRecordCreatedDto dto)
    {
        IntegrationName = "QueryToTable";
        SetDto(dto);
    }
}