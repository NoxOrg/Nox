//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace CryptocashIntegration.Application.Integrations;

public class CountryQueryToCustomTableRecordCreatedEvent: EtlRecordCreatedEvent<IEtlEventDto>, INotification
{
    public CountryQueryToCustomTableRecordCreatedEvent(QueryToCustomTableRecordCreatedDto dto)
    {
        IntegrationName = "QueryToCustomTable";
        SetDto(dto);
    }
}