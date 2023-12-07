// Generated

#nullable enable

using AutoMapper;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Integration.CustomTransformHandlers;

public abstract class {{className}}
{
    public string IntegrationName => "{{integration.Name}}";

    public dynamic InvokeBase(dynamic sourceRecord)
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => { }));
        var result = mapper.Map<dynamic>(sourceRecord);
        return result;
    }
}