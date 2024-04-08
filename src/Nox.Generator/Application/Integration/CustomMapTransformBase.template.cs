// Generated

#nullable enable

using AutoMapper;
using Nox.Integration.Abstractions.Interfaces;

namespace {{codeGenConventions.ApplicationNameSpace}}.Integration.CustomTransform;

public abstract class {{className}}: INoxTransform
{
    public string IntegrationName => "{{integration.Name}}";

    public virtual {{ targetDtoName }} InvokeBase({{ sourceDtoName }} sourceRecord)
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => { }));
        var result = mapper.Map<{{ targetDtoName }}>(sourceRecord);
        return result;
    }
}