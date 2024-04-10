// Generated

#nullable enable

using AutoMapper;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Events;

namespace {{codeGenConventions.ApplicationNameSpace}}.Integration.CustomTransform;

public abstract class {{className}}<TSource>: INoxTransform<INoxTransformDto, INoxTransformDto>
    where TSource: INoxTransformDto, new()
{
    public string IntegrationName => "{{integration.Name}}";
    
    public delegate void TransformEventHandler(object sender, NoxTransformEventArgs<{{sourceDtoName}}, {{targetDtoName}}> args);

    public event TransformEventHandler? TransformEvent;

    private void OnTransform(NoxTransformEventArgs<{{sourceDtoName}}, {{targetDtoName}}> args)
    {
        TransformEvent?.Invoke(this, args);
    }

    public Type SourceType => typeof(TSource);

    public INoxTransformDto Invoke(INoxTransformDto source)
    {
        var args = new NoxTransformEventArgs<{{sourceDtoName}}, {{targetDtoName}}>(({{sourceDtoName}})source);
        OnTransform(args);
        return args.Target;
    }
}