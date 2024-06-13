// Generated
#nullable enable

using System.Globalization;
using CryptocashIntegration.Application.Integration.CustomTransform;
using Nox.Integration.Abstractions.Interfaces;
using AutoMapper;
using Nox.Solution;

namespace {{codeGenConventions.ApplicationNameSpace}}.Integration.CustomTransform;

public abstract class {{className}}: INoxTransform<{{sourceDtoName}}, {{targetDtoName}}>
{
    private readonly IMapper _mapper;
    
    protected {{className}}()
    {
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<{{sourceDtoName}}, {{targetDtoName}}>()
            {{- for map in mappings }}
                {{map}}
            {{- end }};
        }).CreateMapper();
    }
    
    public virtual {{targetDtoName}} Invoke({{sourceDtoName}} source)
    {
        return _mapper.Map<{{sourceDtoName}}, {{targetDtoName}}>(source);
    }

    public string IntegrationName => "{{integrationName}}";

    public Type SourceType => typeof({{sourceDtoName}});

    public Type TargetType => typeof({{targetDtoName}});
}