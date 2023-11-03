﻿// Generated

#nullable enable

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

internal abstract class {{className}}Base : IEntityLocalizedFactory<{{localizedEntityName}}, {{entity.Name}}Entity, {{entity.Name}}UpdateDto>
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

    public virtual void UpdateLocalizedEntity({{ localizedEntityName}} localizedEntity, {{entity.Name}}UpdateDto updateDto, CultureCode cultureCode)
    {
        {{- for attribute in localizedEntityAttributes }}
        {{- if attribute.IsRequired }}
        localizedEntity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(updateDto.{{attribute.Name}}
            {{- if IsNoxTypeSimpleType attribute.Type -}}.NonNullValue<{{SinglePrimitiveTypeForKey attribute}}>()
            {{- else -}}.NonNullValue<{{attribute.Type}}Dto>()
            {{- end}});
        {{- else }}
        localizedEntity.SetIfNotNull(updateDto.{{attribute.Name}}, (localizedEntity) => localizedEntity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(updateDto.{{attribute.Name}}
            {{- if IsNoxTypeSimpleType attribute.Type -}}.ToValueFromNonNull<{{SinglePrimitiveTypeForKey attribute}}>()
            {{- else -}}.ToValueFromNonNull<{{attribute.Type}}Dto>()
            {{- end}}));
        {{- end }}
        {{- end }}
    }

    public virtual void PartialUpdateEntity({{ localizedEntityName}} localizedEntity, Dictionary<string, dynamic> updatedProperties, CultureCode cultureCode)
    {
        {{- for attribute in localizedEntityAttributes }}
            {{- if !IsNoxTypeReadable attribute.Type || attribute.Type == "Formula" -}}
                {{ continue; }}
            {{- end}}

        if (updatedProperties.TryGetValue("{{attribute.Name}}", out var {{attribute.Name}}UpdateValue))
        {
            {{- if attribute.IsRequired }}
            if ({{attribute.Name}}UpdateValue == null)
            {
                throw new ArgumentException("Attribute '{{attribute.Name}}' can't be null");
            }
            {{- else }}
            if ({{attribute.Name}}UpdateValue == null)
            {
                localizedEntity.{{attribute.Name}} = null;
            }
            else
            {{- end }}
            {
                localizedEntity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}({{attribute.Name}}UpdateValue);
            }
        }

        {{- end }}
    }
}