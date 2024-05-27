using System.Globalization;
using CryptocashIntegration.Application.Integration.CustomTransform;
using Nox.Integration.Abstractions.Interfaces;

namespace Cryptocash.Integration.Integrations;

public class JsonToTableTransform: JsonToTableTransformBase, INoxTransform<JsonToTableSourceDto, JsonToTableTargetDto>
{
    public JsonToTableTargetDto Invoke(JsonToTableSourceDto source)
    {
        var result = new JsonToTableTargetDto
        {
            //Map the source to target
            Id = source.CountryId,
            Name = source.CountryName,
            Population = source.NoOfInhabitants,
            CreateDate = DateTime.Parse(source.DateCreated, CultureInfo.InvariantCulture),
            EditDate = string.IsNullOrWhiteSpace(source.DateChanged) ? null : DateTime.Parse(source.DateChanged, CultureInfo.InvariantCulture),
            Etag = new Guid(source.ConcurrencyStamp),
            PopulationMillions = source.NoOfInhabitants/1000000
        };
        return result;
    }
}
