// Generated
{{-func getMapping(sourceName, targetName, targetType, targetIsRequired)
    case targetType | string.downcase
        when "date"
            if (targetIsRequired == "true")
                ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => DateOnly.Parse(src." + sourceName | string.capitalize + ")))"
            else
                ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + " == null ? (DateOnly?)null : DateOnly.Parse(src." + sourceName | string.capitalize + ")))"                
            end    
        when "time"
            if (targetIsRequired == "true")
                ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => TimeOnly.Parse(src." + sourceName | string.capitalize + ")))"
            else
                ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + " == null ? (TimeOnly?)null : TimeOnly.Parse(src." + sourceName | string.capitalize + ")))"                
            end   
        when "datetime"
            if (targetIsRequired == "true")
                ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => DateTime.Parse(src." + sourceName | string.capitalize + ")))"
            else
                ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + " == null ? (DateTime?)null : DateTime.Parse(src." + sourceName | string.capitalize + ")))"                
            end   
        when "guid"
            if (targetIsRequired == "true")
                ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => Guid.NewGuid(src." + sourceName | string.capitalize + ")))"
            else
                ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + " == null ? (Guid?)null : Guid.NewGuid(src." + sourceName | string.capitalize + ")))"                
            end   
        else
            ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + "))"
    end 
end}}

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
            {{- if (integration.Transformation && integration.Transformation.Mapping) }}    
            {{- for map in integration.Transformation.Mapping }}
            {{- if (map.Source) }}
                {{ getMapping map.Source.Name map.Target.Name map.Target.Type map.IsRequired }}
            {{- end }}
            {{- end }}
            {{- end }};
        }).CreateMapper();
    }
    
    public virtual {{targetDtoName}} Invoke({{sourceDtoName}} source)
    {
        return _mapper.Map<{{sourceDtoName}}, {{targetDtoName}}>(source);
    }

    public string IntegrationName => "{{integration.Name}}";

    public Type SourceType => typeof({{sourceDtoName}});

    public Type TargetType => typeof({{targetDtoName}});
}