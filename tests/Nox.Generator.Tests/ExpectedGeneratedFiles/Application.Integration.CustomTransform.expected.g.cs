// Generated

#nullable enable

using AutoMapper;

namespace TestIntegrationSolution.Application.Integration.CustomTransformHandlers;

public abstract class TestIntegrationTransformHandlerBase
{
    public string IntegrationName => "TestIntegration";

    public virtual dynamic InvokeBase(dynamic sourceRecord)
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => { }));
        var result = mapper.Map<dynamic>(sourceRecord);
        return result;
    }
}