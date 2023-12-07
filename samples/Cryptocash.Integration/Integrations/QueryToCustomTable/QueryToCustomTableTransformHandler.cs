using CryptocashIntegration.Application.Integration.CustomTransformHandlers;
using Nox.Integration.Abstractions;

namespace Cryptocash.Integration.Integrations;

public class QueryToCustomTableTransformHandler: QueryToCustomTableTransformHandlerBase, INoxCustomTransformHandler
{
    public dynamic Invoke(dynamic sourceRecord)
    {
        var result = InvokeBase(sourceRecord);
        result.Id = sourceRecord.CountryId;
        result.AsAt = sourceRecord.CreateDate.DateTime;
        
        return result;
    }
}