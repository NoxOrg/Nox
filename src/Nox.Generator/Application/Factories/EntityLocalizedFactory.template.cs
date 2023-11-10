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

internal abstract class {{className}}Base : IEntityLocalizedFactory<{{localizedEntityName}}, {{entity.Name}}Entity, {{entity.Name}}LocalizedCreateDto>
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
            {{key.Name}} = {{key.Type}}.FromDatabase(localizedCreateDto.{{key.Name}}),
            {{- else }} 
            {{key.Name}} = {{key.Type}}.From(localizedCreateDto.{{key.Name}}),
            {{- end }}
            {{- end }}
            {{codeGeneratorState.LocalizationCultureField}} = CultureCode.From(localizedCreateDto.{{codeGeneratorState.LocalizationCultureField}}),
            {{- for attribute in localizedEntityAttributes }}
            {{attribute.Name}} = {{attribute.Type}}.From(localizedCreateDto.{{attribute.Name}}.ToValueFromNonNull()),
            {{- end }}
        };

        return localizedEntity;
    }
}