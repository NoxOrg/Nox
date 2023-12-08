using CryptocashIntegration.Application.Dto;

namespace Cryptocash.Integration.Integrations;

internal static class CountryQueryToCustomTableIntegrationHelper
{
    internal static CountryQueryToCustomTableDto FromDynamic(dynamic record)
    {
        var result = new CountryQueryToCustomTableDto
        {
            Id = record.Id,
            Name = record.Name,
            Etag = record.Etag,
            Population = record.Population,
            CreateDate = record.CreateDate,
            EditDate = record.EditDate,
        };
        
        return result;
    } 
}