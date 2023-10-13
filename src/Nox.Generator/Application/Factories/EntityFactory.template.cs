{{- ownedEntities = entity.OwnedRelationships | array.map "Entity" }}
{{- func fieldFactoryName
    ret (string.downcase $0 + "Factory")
end -}}
// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.DomainNameSpace}};
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Factories;

internal abstract class {{className}}Base : IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto>
{
    {{- for ownedEntity in ownedEntities #Factories Properties for owned entitites}}
    protected IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{ownedEntity}}, {{ownedEntity}}CreateDto, {{ownedEntity}}UpdateDto> {{ownedEntity}}Factory {get;}
    {{- end }}

    public {{className}}Base
    (
        {{- for ownedEntity in ownedEntities #Factories Properties for owned entitites}}
        IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{ownedEntity}}, {{ownedEntity}}CreateDto, {{ownedEntity}}UpdateDto> {{fieldFactoryName ownedEntity}}{{if !for.last}},{{end}}
        {{- end }}
        )
    {
        {{- for ownedEntity in ownedEntities #Factories Properties for owned entitites}}
        {{ ownedEntity}}Factory = {{fieldFactoryName ownedEntity}};
        {{- end }}
    }

    public virtual {{entity.Name}}Entity CreateEntity({{entity.Name}}CreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity({{entity.Name}}Entity entity, {{entity.Name}}UpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity({{entity.Name}}Entity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private {{codeGeneratorState.DomainNameSpace}}.{{ entity.Name }} ToEntity({{entity.Name}}CreateDto createDto)
    {
        var entity = new {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}();
        {{- for key in entity.Keys }}
            {{- if key.Type == "Nuid" || key.Type == "AutoNumber" || key.Type == "Guid" -}}
                {{ continue; -}}
            {{- end }}
        entity.{{key.Name}} = {{entity.Name}}Metadata.Create{{key.Name}}(createDto.{{key.Name}});
        {{- end }}
        {{- for attribute in entity.Attributes }}
            {{- if !IsNoxTypeReadable attribute.Type || attribute.Type == "Formula" -}}
                {{ continue; }}
            {{- end}}
        {{- if !attribute.IsRequired }}
        if (createDto.{{attribute.Name}} is not null)
            {{- if IsNoxTypeSimpleType attribute.Type -}}
        entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(createDto.{{attribute.Name}}.NonNullValue<{{SinglePrimitiveTypeForKey attribute}}>());
            {{- else -}}
        entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(createDto.{{attribute.Name}}.NonNullValue<{{attribute.Type}}Dto>());
            {{- end}}
        {{- else }}
        entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(createDto.{{attribute.Name}});
        {{- end }}
        {{- end }}

        {{- for key in entity.Keys ~}}
		    {{- if key.Type == "Nuid" }}
		entity.Ensure{{key.Name}}();
		    {{- end }}
            {{- if key.Type == "Guid" }}
        entity.Ensure{{key.Name}}(createDto.{{key.Name}});
            {{- end }}
		{{- end }}

        {{- for relationship in entity.OwnedRelationships }}
            {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
        entity.{{relationship.Name}} = createDto.{{relationship.Name}}.Select(dto => {{relationship.Entity}}Factory.CreateEntity(dto)).ToList();
            {{- else}}
        if (createDto.{{relationship.Name}} is not null)
        {
            entity.{{relationship.Name}} = {{relationship.Entity}}Factory.CreateEntity(createDto.{{relationship.Name}});
        }
            {{-end}}
        {{- end }}
        return entity;
    }

    private void UpdateEntityInternal({{entity.Name}}Entity entity, {{entity.Name}}UpdateDto updateDto)
    {
        {{- for attribute in entity.Attributes }}
            {{- if !IsNoxTypeReadable attribute.Type || attribute.Type == "Formula" -}}
                {{ continue; }}
            {{- end}}
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

        {{- for key in entity.Keys ~}}
		    {{- if key.Type == "Nuid" }}
		entity.Ensure{{key.Name}}();
		    {{- end }}
		{{- end }}
    }

    private void PartialUpdateEntityInternal({{entity.Name}}Entity entity, Dictionary<string, dynamic> updatedProperties)
    {
        {{- for attribute in entity.Attributes }}
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
            if ({{attribute.Name}}UpdateValue == null) { entity.{{attribute.Name}} = null; }
            else
            {{- end }}
            {
                entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}({{attribute.Name}}UpdateValue);
            }
        }

        {{- end }}

        {{- for key in entity.Keys ~}}
		    {{- if key.Type == "Nuid" }}
		entity.Ensure{{key.Name}}();
		    {{- end }}
		{{- end }}
    }
}

internal partial class {{className}} : {{className}}Base
{
    {{- if ownedEntities | array.size > 0 #Factories for owned entitites}}
    public {{className}}
    (
        {{- for ownedEntity in ownedEntities #Factories Properties for owned entitites}}
        IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{ownedEntity}}, {{ownedEntity}}CreateDto, {{ownedEntity}}UpdateDto> {{fieldFactoryName ownedEntity}}{{if !for.last}},{{end}}
        {{- end }}
    ) : base({{ ownedEntities | array.each @fieldFactoryName | array.join "," }})
    {}
    {{- end }}
}