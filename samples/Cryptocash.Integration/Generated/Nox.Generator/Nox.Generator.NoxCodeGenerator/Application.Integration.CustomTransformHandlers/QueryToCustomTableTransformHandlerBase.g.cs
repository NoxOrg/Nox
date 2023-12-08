// Generated

#nullable enable

using AutoMapper;

namespace CryptocashIntegration.Application.Integration.CustomTransformHandlers;

public abstract class QueryToCustomTableTransformHandlerBase
{
    public string IntegrationName => "QueryToCustomTable";

    public dynamic InvokeBase(dynamic sourceRecord)
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => { }));
        var result = mapper.Map<dynamic>(sourceRecord);
        return result;
    }
}