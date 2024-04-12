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
            CreateDate = DateTime.Parse(source.DateCreated),
            EditDate = string.IsNullOrWhiteSpace(source.DateChanged) ? null : DateTime.Parse(source.DateChanged),
            Etag = new Guid(source.ConcurrencyStamp)
        };
        return result;
    }
}
