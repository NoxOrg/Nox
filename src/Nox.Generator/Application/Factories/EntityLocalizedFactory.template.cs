// Generated

#nullable enable

using System.Net.Mime;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Solution;
using Nox.Types;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.DomainNameSpace}};
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Factories;

internal partial class {{className}} : {{className}}Base
{
}

internal abstract class {{className}}Base : IEntityLocalizedFactory<{{localizedEntityName}}, {{entity.Name}}Entity, {{entity.Name}}LocalizedCreateDto, {{entity.Name}}LocalizedUpdateDto>
{
    public virtual {{localizedEntityName}} CreateLocalizedEntity({{entity.Name}}Entity entity, CultureCode cultureCode)
    {
        var localizedEntity = new {{localizedEntityName}}
        {
            {{- for key in entity.Keys }}
            {{key.Name}} = entity.{{key.Name}},
            {{- end }}
            {{codeGeneratorState.LocalizationCultureField}} = cultureCode,
            {{- for attribute in localizedEntityAttributes }}
            {{attribute.Name}} = entity.{{attribute.Name}},
            {{- end }}
        };

        return localizedEntity;
    }
    
    public virtual {{localizedEntityName}} CreateLocalizedEntity({{entity.Name}}LocalizedCreateDto localizedCreateDto)
    {
        var localizedEntity = new {{localizedEntityName}}
        {
            {{-}}
            {{- for key in entity.Keys }}
                {{- if key.Type == "Nuid" || key.Type == "AutoNumber" -}}
                // {{key.Name}} = {{key.Type}}.FromDatabase(localizedCreateDto.{{key.Name}}),
                {{- else }} 
                // {{key.Name}} = {{key.Type}}.From(localizedCreateDto.{{key.Name}}),
                {{- end }}
            {{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(localizedCreateDto.{{key.Name}}),
            {{- end }}
            {{codeGeneratorState.LocalizationCultureField}} = CultureCode.From(localizedCreateDto.{{codeGeneratorState.LocalizationCultureField}}),
            // {{- for attribute in localizedEntityAttributes }}
            // {{attribute.Name}} = {{attribute.Type}}.From(localizedCreateDto.{{attribute.Name}}.ToValueFromNonNull()),
            // {{- end }}
            
            {{- for attribute in localizedEntityAttributes }}
            
                {{- if !attribute.IsRequired }}
            if (localizedCreateDto.{{attribute.Name}} is not null)
                    {{- if IsNoxTypeSimpleType attribute.Type -}}
            {{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(localizedCreateDto.{{attribute.Name}}.NonNullValue<{{SinglePrimitiveTypeForKey attribute}}>()),
                    {{- else -}}
            {{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(localizedCreateDto.{{attribute.Name}}.NonNullValue<{{attribute.Type}}Dto>()),
                    {{- end}}
            {{- else }}
            {{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(localizedCreateDto.{{attribute.Name}}),
                {{- end }}
            {{- end }}
        };

        return localizedEntity;
    }

    public virtual void UpdateLocalizedEntity({{localizedEntityName}} entity, {{entity.Name}}LocalizedUpdateDto updateDto)
    {
        {{- for attribute in localizedEntityAttributes }}
            {{- if attribute.IsRequired }}
        entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(updateDto.{{attribute.Name}}
            {{- if IsNoxTypeSimpleType attribute.Type -}}.NonNullValue<{{SinglePrimitiveTypeForKey attribute}}>()
            {{- else -}}.NonNullValue<{{attribute.Type}}Dto>()
            {{- end}});
            {{- else}}
        if (updateDto.{{attribute.Name}} == null) { entity.{{attribute.Name}} = null; } else {
            entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(updateDto.{{attribute.Name}}
            {{- if IsNoxTypeSimpleType attribute.Type -}}.ToValueFromNonNull<{{SinglePrimitiveTypeForKey attribute}}>()
            {{- else -}}.ToValueFromNonNull<{{attribute.Type}}Dto>()
            {{- end}});
        }
            {{- end }}
        {{- end }}
        
    }
}