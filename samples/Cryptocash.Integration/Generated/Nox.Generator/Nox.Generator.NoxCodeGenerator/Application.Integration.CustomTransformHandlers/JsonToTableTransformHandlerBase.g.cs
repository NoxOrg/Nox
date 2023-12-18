// Generated

#nullable enable

using AutoMapper;

namespace CryptocashIntegration.Application.Integration.CustomTransformHandlers;

public abstract class JsonToTableTransformHandlerBase
{
    public string IntegrationName => "JsonToTable";

    public virtual dynamic InvokeBase(dynamic sourceRecord)
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => { }));
        var result = mapper.Map<dynamic>(sourceRecord);
        return result;
    }
}