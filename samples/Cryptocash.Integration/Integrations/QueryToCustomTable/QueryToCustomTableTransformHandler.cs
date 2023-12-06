using System.Dynamic;
using CryptocashIntegration.Application.Integration.CustomTransformHandlers;
using Nox.Integration.Abstractions;

namespace Cryptocash.Integration.Integrations;

public class QueryToCustomTableTransformHandler: QueryToCustomTableTransformHandlerBase, INoxCustomTransformHandler
{
    public dynamic Invoke(dynamic sourceRecord)
    {
        dynamic result = new ExpandoObject();
        result.Id = sourceRecord.CountryId;
        result.Name = sourceRecord.Name;
        result.Population = sourceRecord.Population;
        result.AsAt = DateTime.Now;
        result.Etag = Guid.NewGuid();
        return result;
    }
}