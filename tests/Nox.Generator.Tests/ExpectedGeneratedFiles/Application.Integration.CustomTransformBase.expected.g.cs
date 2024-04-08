// Generated

#nullable enable

using AutoMapper;
using Nox.Integration.Abstractions.Interfaces;

namespace TestIntegrationSolution.Application.Integration.CustomTransform;

public abstract class TestIntegrationTransformBase: INoxTransform
{
    public string IntegrationName => "TestIntegration";

    public virtual dynamic InvokeBase(dynamic sourceRecord)
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => { }));
        var result = mapper.Map<dynamic>(sourceRecord);
        return result;
    }
}