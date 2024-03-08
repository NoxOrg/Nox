using CryptocashIntegration.Application.Integration.CustomTransform;
using Nox.Integration.Abstractions.Interfaces;

namespace Cryptocash.Integration.Integrations;

public class QueryToCustomTableTransform: QueryToCustomTableTransformBase, INoxCustomTransform
{
    public dynamic Invoke(dynamic sourceRecord)
    {
        var result = InvokeBase(sourceRecord);
        result.Id = sourceRecord.CountryId;
        result.AsAt = sourceRecord.CreateDate.DateTime;
        return result;
    }
    
}