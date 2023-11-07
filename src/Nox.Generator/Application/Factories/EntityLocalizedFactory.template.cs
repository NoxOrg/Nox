// Generated

#nullable enable

using System.Net.Mime;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.DomainNameSpace}};
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Factories;

internal partial class {{className}} : {{className}}Base
{
}

internal abstract class {{className}}Base : IEntityLocalizedFactory<{{localizedEntityName}}, {{entity.Name}}Entity, {{entity.Name}}LocalizedDto>
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
    
    public virtual {{localizedEntityName}} CreateLocalizedEntityFromDto({{entity.Name}}LocalizedDto localizedDto)
    {
        var localizedEntity = new {{localizedEntityName}}
        {
            
            {{- for key in entity.Keys }}
            {{- if key.Type == "Nuid" || key.Type == "AutoNumber" -}}
            // Nuid and AutoNumber should be set from database
            {{key.Name}} = {{key.Type}}.FromDatabase(localizedDto.{{key.Name}}),
            {{- else }} 
            {{key.Name}} = {{key.Type}}.From(localizedDto.{{key.Name}}),
            {{- end }}
            {{- end }}
            {{codeGeneratorState.LocalizationCultureField}} = CultureCode.From(localizedDto.{{codeGeneratorState.LocalizationCultureField}}),
            {{- for attribute in localizedEntityAttributes }}
            {{attribute.Name}} = {{attribute.Type}}.From(localizedDto.{{attribute.Name}}.NonNullValue()),
            {{- end }}
        };

        return localizedEntity;
    }
}