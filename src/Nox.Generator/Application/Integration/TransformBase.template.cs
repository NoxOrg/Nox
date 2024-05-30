// Generated
{{-func getMapping(sourceName, sourceType, targetName, targetType, targetIsRequired)
    sourceType = sourceType | string.downcase
    targetType = targetType | string.downcase
    if (targetIsRequired == "true")
        case sourceType
            when "date"
                case targetType
                    when "datetime"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + ".ToDateTime(new TimeOnly(0, 0))))"
                    else
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + "))"        
                end
            when "datetime"
                case targetType
                    when "date"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => DateOnly.FromDateTime(src." + sourceName | string.capitalize + ")))"
                    when "time"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => TimeOnly.FromDateTime(src." + sourceName | string.capitalize + ")))"
                    else
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + "))"        
                end
            when "string"
                case targetType
                    when "integer"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => int.Parse(src." + sourceName | string.capitalize + ")))"
                    when "double"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => double.Parse(src." + sourceName | string.capitalize + ")))"
                    when "bool"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => bool.Parse(src." + sourceName | string.capitalize + ")))"
                    when "string"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + "))"
                    when "date"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => DateOnly.Parse(src." + sourceName | string.capitalize + ")))"
                    when "time"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => TimeOnly.Parse(src." + sourceName | string.capitalize + ")))"
                    when "datetime"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => DateTime.Parse(src." + sourceName | string.capitalize + ")))"
                    when "guid"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => Guid.Parse(src." + sourceName | string.capitalize + ")))"
                end
            else
                ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + "))"
        end
    else
        case sourceType
            when "date"
                case targetType
                    when "datetime"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src == null ? (DateTime?)null : src." + sourceName | string.capitalize + ".ToDateTime(new TimeOnly(0, 0))))"
                    else
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + "))"        
                end
            when "datetime"
                case targetType
                    when "date"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src == null ? (DateOnly?)null : DateOnly.FromDateTime(src." + sourceName | string.capitalize + ")))"
                    when "time"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src == null ? (TimeOnly?)null : TimeOnly.FromDateTime(src." + sourceName | string.capitalize + ")))"
                    else
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + "))"        
                end
            when "string"
                case targetType
                    when "integer"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src." + sourceName | string.capitalize + ") ? (int?)null : int.Parse(src." + sourceName | string.capitalize + ")))"
                    when "double"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src." + sourceName | string.capitalize + ") ? (double?)null : double.Parse(src." + sourceName | string.capitalize + ")))"
                    when "bool"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src." + sourceName | string.capitalize + ") ? (bool?)null : bool.Parse(src." + sourceName | string.capitalize + ")))"
                    when "string"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src." + sourceName | string.capitalize + ") ? (string?)null : src." + sourceName | string.capitalize + "))"
                    when "date"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src." + sourceName | string.capitalize + ") ? (DateOnly?)null : DateOnly.Parse(src." + sourceName | string.capitalize + ")))"
                    when "time"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src." + sourceName | string.capitalize + ") ? (TimeOnly?)null : TimeOnly.Parse(src." + sourceName | string.capitalize + ")))"
                    when "datetime"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src." + sourceName | string.capitalize + ") ? (DateTime?)null : DateTime.Parse(src." + sourceName | string.capitalize + ")))"
                    when "guid"
                        ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src." + sourceName | string.capitalize + ") ? (Guid?)null : Guid.Parse(src." + sourceName | string.capitalize + ")))"
                end
            else
                ret ".ForMember(dest => dest." + targetName | string.capitalize + ", opt => opt.MapFrom(src => src." + sourceName | string.capitalize + "))"
        end
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
                //{{ map.Source.Type }} -> {{ map.Target.Type }}{{- if (!map.IsRequired) }}?{{- end}}
                {{ getMapping map.Source.Name map.Source.Type map.Target.Name map.Target.Type map.IsRequired }}
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