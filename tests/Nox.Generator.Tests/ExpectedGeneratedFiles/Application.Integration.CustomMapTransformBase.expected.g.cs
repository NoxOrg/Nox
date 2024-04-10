// Generated

#nullable enable

using AutoMapper;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Events;

namespace TestIntegrationSolution.Application.Integration.CustomTransform;

public abstract class TestIntegrationTransformBase<TSource>: INoxTransform<INoxTransformDto, INoxTransformDto>
    where TSource: INoxTransformDto, new()
{
    public string IntegrationName => "TestIntegration";
    
    public delegate void TransformEventHandler(object sender, NoxTransformEventArgs<TestIntegrationSourceDto, TestIntegrationTargetDto> args);

    public event TransformEventHandler? TransformEvent;

    private void OnTransform(NoxTransformEventArgs<TestIntegrationSourceDto, TestIntegrationTargetDto> args)
    {
        TransformEvent?.Invoke(this, args);
    }

    public Type SourceType => typeof(TSource);

    public INoxTransformDto Invoke(INoxTransformDto source)
    {
        var args = new NoxTransformEventArgs<TestIntegrationSourceDto, TestIntegrationTargetDto>((TestIntegrationSourceDto)source);
        OnTransform(args);
        return args.Target;
    }
}