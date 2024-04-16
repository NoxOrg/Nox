// Generated

#nullable enable

using AutoMapper;

namespace TestIntegrationSolution.Application.Integration.CustomTransform;

public abstract class TestIntegrationTransformBase
{
    public string IntegrationName => "TestIntegration";

    public Type SourceType => typeof(TestIntegrationSourceDto);

    public Type TargetType => typeof(TestIntegrationTargetDto);
}