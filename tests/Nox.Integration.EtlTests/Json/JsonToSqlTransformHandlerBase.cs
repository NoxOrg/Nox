using Nox.Integration.Abstractions.Events;
using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.EtlTests.Json;

public abstract class JsonToSqlTransformHandlerBase<TSource>: INoxTransform<INoxTransformDto, INoxTransformDto>
    where TSource: INoxTransformDto, new()
{
    public delegate void TransformEventHandler(object sender, NoxTransformEventArgs<SourceDto, TargetDto> args);

    public event TransformEventHandler? TransformEvent;

    private void OnTransform(NoxTransformEventArgs<SourceDto, TargetDto> args)
    {
        TransformEvent?.Invoke(this, args);
    }
        
    public string IntegrationName => "JsonToSqlIntegration";
    public Type SourceType => typeof(TSource);

    public INoxTransformDto Invoke(INoxTransformDto source)
    {
        var args = new NoxTransformEventArgs<SourceDto, TargetDto>((SourceDto)source);
        
        OnTransform(args);
        return args.Target;
    }
}

