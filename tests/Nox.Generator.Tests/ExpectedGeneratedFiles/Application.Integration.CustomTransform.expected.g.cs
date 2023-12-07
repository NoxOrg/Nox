// Generated

#nullable enable

using AutoMapper;

namespace SampleIntegrationSolution.Application.Integration.CustomTransformHandlers;

public abstract class SampleIntegrationCustomTransformHandlerBase
{
    public string IntegrationName => "SampleIntegration";
    
    public dynamic InvokeBase(dynamic sourceRecord)
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => { }));
        var result = mapper.Map<dynamic>(sourceRecord);
        return result;
    }
}