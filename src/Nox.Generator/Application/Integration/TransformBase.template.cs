// Generated

#nullable enable

using AutoMapper;

namespace {{codeGenConventions.ApplicationNameSpace}}.Integration.CustomTransform;

public abstract class {{className}}
{
    public string IntegrationName => "{{integration.Name}}";

    public Type SourceType => typeof({{sourceDtoName}});

    public Type TargetType => typeof({{targetDtoName}});
}