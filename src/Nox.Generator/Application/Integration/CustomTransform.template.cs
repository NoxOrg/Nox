// Generated

#nullable enable

using AutoMapper;

namespace {{codeGenConventions.ApplicationNameSpace}}.Integration.CustomTransform;

public abstract class {{className}}
{
    public string IntegrationName => "{{integration.Name}}";

    public virtual dynamic InvokeBase(dynamic sourceRecord)
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => { }));
        var result = mapper.Map<dynamic>(sourceRecord);
        return result;
    }
}