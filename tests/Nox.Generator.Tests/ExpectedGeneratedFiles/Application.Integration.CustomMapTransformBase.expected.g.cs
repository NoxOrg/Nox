// Generated

#nullable enable

using AutoMapper;
using Nox.Integration.Abstractions.Interfaces;

namespace TestIntegrationSolution.Application.Integration.CustomTransform;

public abstract class TestIntegrationTransformBase: INoxTransform
{
    public string IntegrationName => "TestIntegration";

    public virtual TestIntegrationTargetDto InvokeBase(TestIntegrationSourceDto sourceRecord)
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => { }));
        var result = mapper.Map<TestIntegrationTargetDto>(sourceRecord);
        return result;
    }
}