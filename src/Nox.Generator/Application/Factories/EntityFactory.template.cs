{{- ownedEntities = entity.OwnedRelationships | array.map "Entity" }}
{{-entityCreateDto = entity.IsOwnedEntity ? (entity.Name + "UpsertDto") : (entity.Name + "CreateDto") }}
{{-entityUpdateDto = entity.IsOwnedEntity ? (entity.Name + "UpsertDto") : (entity.Name + "UpdateDto") }}
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

internal abstract class {{className}}Base : IEntityFactory<{{entity.Name}}Entity, {{entityCreateDto}}, {{entityUpdateDto}}>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("{{codeGeneratorState.Solution.Application.Localization.DefaultCulture}}");

    {{- for ownedEntity in ownedEntities #Factories Properties for owned entitites}}
    protected IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{ownedEntity}}, {{ownedEntity}}UpsertDto, {{ownedEntity}}UpsertDto> {{ownedEntity}}Factory {get;}
    {{- end }}

    public {{className}}Base(
        {{- for ownedEntity in ownedEntities #Factories Properties for owned entitites}}
        IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{ownedEntity}}, {{ownedEntity}}UpsertDto, {{ownedEntity}}UpsertDto> {{fieldFactoryName ownedEntity}}{{if !for.last}},{{end}}
        {{- end -}})
    {
        {{- for ownedEntity in ownedEntities #Factories Properties for owned entitites}}
        {{ ownedEntity}}Factory = {{fieldFactoryName ownedEntity}};
        {{- end }}
    }

    public virtual {{entity.Name}}Entity CreateEntity({{entityCreateDto}} createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity({{entity.Name}}Entity entity, {{entityUpdateDto}} updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity({{entity.Name}}Entity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private {{codeGeneratorState.DomainNameSpace}}.{{ entity.Name }} ToEntity({{entityCreateDto}} createDto)
    {
        var entity = new {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}();
        {{- for key in entity.Keys }}
            {{- if !IsNoxTypeCreatable key.Type || key.Type == "Guid" -}}
                {{ continue; -}}
            {{- end }}
        entity.{{key.Name}} = {{entity.Name}}Metadata.Create{{key.Name}}(createDto.{{key.Name}}{{if entity.IsOwnedEntity}}!{{end}});
        {{- end }}
        {{- for attribute in entity.Attributes }}
            {{- if !IsNoxTypeReadable attribute.Type || attribute.Type == "Formula" || attribute.Type == "AutoNumber" -}}
                {{ continue; }}
            {{- end}}
        {{- if !attribute.IsRequired }}
        entity.SetIfNotNull(createDto.{{attribute.Name}}, (entity) => entity.{{attribute.Name}} = 
            {{- if IsNoxTypeSimpleType attribute.Type -}}
        {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(createDto.{{attribute.Name}}.NonNullValue<{{SinglePrimitiveTypeForKey attribute}}>()));
            {{- else -}}
        {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(createDto.{{attribute.Name}}.NonNullValue<{{attribute.Type}}Dto>()));
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
            {{- relationshipName = GetNavigationPropertyName entity relationship }}
            {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
        createDto.{{relationshipName}}.ForEach(dto => entity.CreateRefTo{{relationshipName}}({{relationship.Entity}}Factory.CreateEntity(dto)));
            {{- else}}
        if (createDto.{{relationshipName}} is not null)
        {
            entity.CreateRefTo{{relationshipName}}({{relationship.Entity}}Factory.CreateEntity(createDto.{{relationshipName}}));
        }
            {{-end}}
        {{- end }}
        return entity;
    }

    private void UpdateEntityInternal({{entity.Name}}Entity entity, {{entityUpdateDto}} updateDto, Nox.Types.CultureCode cultureCode)
    {
        {{- for attribute in entity.Attributes }}
            {{- if !IsNoxTypeReadable attribute.Type || !IsNoxTypeUpdatable attribute.Type -}}
                {{ continue; }}
            {{- end}}
        {{ if attribute.IsLocalized }}if(IsDefaultCultureCode(cultureCode)) {{ end }}
        {{- if attribute.IsRequired -}}
        entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(updateDto.{{attribute.Name}}
            {{- if IsNoxTypeSimpleType attribute.Type -}}.NonNullValue<{{SinglePrimitiveTypeForKey attribute}}>()
            {{- else -}}.NonNullValue<{{attribute.Type}}Dto>()
            {{- end}});
        {{- else -}}
        if(updateDto.{{attribute.Name}} is null)
        {
             entity.{{attribute.Name}} = null;
        }
        else
        {
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

    private void PartialUpdateEntityInternal({{entity.Name}}Entity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        {{- for attribute in entity.Attributes }}
            {{- if !IsNoxTypeReadable attribute.Type || !IsNoxTypeUpdatable attribute.Type -}}
                {{ continue; }}
            {{- end}}

        if ({{- if attribute.IsLocalized }}IsDefaultCultureCode(cultureCode) && {{ end -}} updatedProperties.TryGetValue("{{attribute.Name}}", out var {{attribute.Name}}UpdateValue))
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class {{className}} : {{className}}Base
{
    {{- if ownedEntities | array.size > 0 #Factories for owned entitites}}
    public {{className}}
    (
        {{- for ownedEntity in ownedEntities #Factories Properties for owned entitites}}
        IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{ownedEntity}}, {{ownedEntity}}UpsertDto, {{ownedEntity}}UpsertDto> {{fieldFactoryName ownedEntity}}{{if !for.last}},{{end}}
        {{- end }}
    ) : base({{ ownedEntities | array.each @fieldFactoryName | array.join "," }})
    {}
    {{- end }}
}