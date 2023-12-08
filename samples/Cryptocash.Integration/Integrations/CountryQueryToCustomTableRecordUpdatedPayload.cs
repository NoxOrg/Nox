using CryptocashIntegration.Application.Dto;
using Nox.Integration.Abstractions;

namespace Cryptocash.Integration.Integrations;

public class CountryQueryToCustomTableRecordUpdatedPayload: CountryQueryToCustomTableUpdateDto, INoxEtlEventPayload
{
    
}