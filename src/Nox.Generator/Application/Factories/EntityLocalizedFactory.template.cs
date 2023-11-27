﻿{{-entityUpdateDto = entity.IsOwnedEntity ? (entity.Name + "UpsertDto") : (entity.Name + "UpdateDto") -}}
// Generated

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

internal abstract class {{className}}Base : IEntityLocalizedFactory<{{localizedEntityName}}, {{entity.Name}}Entity, {{entityUpdateDto}}>
{
    public virtual {{localizedEntityName}} CreateLocalizedEntity({{entity.Name}}Entity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = new {{localizedEntityName}}
        {
            {{entity.Name}} = entity,
            {{codeGeneratorState.LocalizationCultureField}} = cultureCode,
        };

        if (copyEntityAttributes)
        { 
            {{- for attribute in entityLocalizedAttributes }}
            localizedEntity.{{attribute.Name}} = entity.{{attribute.Name}};
            {{- end }}
        }

        return localizedEntity;
    }

    public virtual void UpdateLocalizedEntity({{ localizedEntityName}} localizedEntity, {{entityUpdateDto}} updateDto)
    {
        {{- for attribute in entityLocalizedAttributes }}
        localizedEntity.{{attribute.Name}} = updateDto.{{attribute.Name}} == null
            ? null
            : {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(updateDto.{{attribute.Name}}
            {{- if IsNoxTypeSimpleType attribute.Type -}}.ToValueFromNonNull<{{SinglePrimitiveTypeForKey attribute}}>()
            {{- else -}}.ToValueFromNonNull<{{attribute.Type}}Dto>()
            {{- end}});
        {{- end }}
    }

    public virtual void PartialUpdateLocalizedEntity({{ localizedEntityName}} localizedEntity, Dictionary<string, dynamic> updatedProperties)
    {
        {{- for attribute in entityLocalizedAttributes }}
            {{- if !IsNoxTypeReadable attribute.Type || attribute.Type == "Formula" -}}
                {{ continue; }}
            {{- end}}

        if (updatedProperties.TryGetValue("{{attribute.Name}}", out var {{attribute.Name}}UpdateValue))
        {
            localizedEntity.{{attribute.Name}} = {{attribute.Name}}UpdateValue == null
                ? null
                : {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}({{attribute.Name}}UpdateValue);
        }

        {{- end }}
    }
}