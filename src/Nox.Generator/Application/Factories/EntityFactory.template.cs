{{- ownedEntities = entity.OwnedRelationships | array.map "Entity" }}
{{-entityCreateDto = entity.IsOwnedEntity ? (entity.Name + "UpsertDto") : (entity.Name + "CreateDto") }}
{{-entityUpdateDto = entity.IsOwnedEntity ? (entity.Name + "UpsertDto") : (entity.Name + "UpdateDto") }}
{{- func fieldFactoryName
    ret (string.downcase $0 + "Factory")
end -}}
{{- func keyType(key)
   ret (key.Type == "EntityId") ? (SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity) : (SinglePrimitiveTypeForKey key)
end -}}
{{- func attributeType(attribute)
	ret (IsNoxTypeSimpleType attribute.Type) ? (SinglePrimitiveTypeForKey attribute) : (attribute.Type + "Dto")
end -}}
{{~ injectRepository = ((entity.OwnedRelationships | array.size) > 0) || (entity.IsLocalized) || (entity.Attributes | array.map "Type" | array.uniq | array.contains 'ReferenceNumber' ) ~}}
{{- func getConstructorParams
    constructor = {}
    constructor.Params = []
    constructor.Names = []
    if injectRepository
        constructor.Params = constructor.Params | array.add "IRepository repository"
        constructor.Names = constructor.Names | array.add "repository"
    end
    if entity.IsLocalized
        constructor.Params = constructor.Params | array.add ("IEntityLocalizedFactory<" + entity.Name + "Localized, " + entity.Name + "Entity, " + entityUpdateDto + "> " + (ToLowerFirstChar  entity.Name) + "LocalizedFactory")
        constructor.Names = constructor.Names | array.add ((ToLowerFirstChar  entity.Name) + "LocalizedFactory")
    end
        
    for ownedEntity in ownedEntities
        constructor.Params = constructor.Params | array.add ("IEntityFactory<" + codeGeneratorState.DomainNameSpace + "." + ownedEntity + ", " + ownedEntity + "UpsertDto, " + ownedEntity + "UpsertDto> " + (fieldFactoryName ownedEntity))
        constructor.Names = constructor.Names | array.add ((fieldFactoryName ownedEntity))
    end
    ret constructor
end -}}
{{- constructor = getConstructorParams }}
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

internal partial class {{className}} : {{className}}Base
{
    public {{className}}
    (
    {{-for p in constructor.Params }}
        {{p}}{{if !(for.last)}},{{end}}
    {{- end }}
    ) : base({{-for p in constructor.Names }}{{p}}{{if !(for.last)}}, {{end}}{{- end }})
    {}
}

internal abstract class {{className}}Base : IEntityFactory<{{entity.Name}}Entity, {{entityCreateDto}}, {{entityUpdateDto}}>
{
    {{- if entity.IsLocalized }}
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("{{codeGeneratorState.Solution.Application.Localization.DefaultCulture}}");
    protected readonly IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entityUpdateDto}}> {{entity.Name}}LocalizedFactory;
    {{- end }}

    {{- if injectRepository }}
    private readonly IRepository _repository;
    {{- end }}

    {{- for ownedEntity in ownedEntities #Factories Properties for owned entitites}}
    protected IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{ownedEntity}}, {{ownedEntity}}UpsertDto, {{ownedEntity}}UpsertDto> {{ownedEntity}}Factory {get;}
    {{- end }}

    public {{className}}Base(
    {{-for p in constructor.Params }}
        {{p}}{{if !(for.last)}},{{end}}
    {{- end }}
        )
    {
        {{- if injectRepository }}
        _repository = repository;
        {{- end }}
        {{- if entity.IsLocalized }}
        {{entity.Name}}LocalizedFactory = {{ToLowerFirstChar  entity.Name}}LocalizedFactory;
        {{- end }}
        {{- for ownedEntity in ownedEntities #Factories Properties for owned entitites}}
        {{ ownedEntity}}Factory = {{fieldFactoryName ownedEntity}};
        {{- end }}
    }

    public virtual async Task<{{entity.Name}}Entity> CreateEntityAsync({{entityCreateDto}} createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            {{- if entity.IsLocalized }}
            {{entity.Name}}LocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
            {{- end }}
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof({{entity.Name}}Entity));
        }        
    }

    public virtual async Task UpdateEntityAsync({{entity.Name}}Entity entity, {{entityUpdateDto}} updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
        {{- if entity.IsLocalized }}
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
            await {{entity.Name}}LocalizedFactory.UpdateLocalizedEntityAsync(entity, updateDto, cultureCode);
        {{- else }}
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        {{- end }}
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof({{entity.Name}}Entity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync({{entity.Name}}Entity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        {{- if entity.IsLocalized }}
            await {{entity.Name}}LocalizedFactory.PartialUpdateLocalizedEntityAsync(entity, updatedProperties, cultureCode);
        {{else}}
            await Task.CompletedTask;
        {{- end }}
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof({{entity.Name}}Entity));
        }   
    }

    private async Task<{{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}> ToEntityAsync({{entityCreateDto}} createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}();
        {{- for key in entity.Keys }}
            {{- if !IsNoxTypeCreatable key.Type || key.Type == "Guid" -}}
                {{ continue; -}}
            {{- end }}
        exceptionCollector.Collect("{{key.Name}}",() => entity.{{key.Name}} = {{entity.Name}}Metadata.Create{{key.Name}}(createDto.{{key.Name}}.NonNullValue<{{keyType key}}>()));
        {{- end }}

        {{- for attribute in entity.Attributes }}
            {{- if !IsNoxTypeCreatable attribute.Type -}}
                {{ continue; }}
            {{- end}}
        exceptionCollector.Collect("{{attribute.Name}}", () => entity.SetIfNotNull(createDto.{{attribute.Name}}, (entity) => entity.{{attribute.Name}} = 
            {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(createDto.{{attribute.Name}}.NonNullValue<{{attributeType attribute}}>())));
        {{- end }}

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        {{- for key in entity.Keys ~}}		   
            {{- if key.Type == "Guid" }}
        entity.Ensure{{key.Name}}(createDto.{{key.Name}});
            {{- end }}        
		{{- end }}

        {{- awaiting = false
            allAttributes = array.concat entity.Keys entity.Attributes ~}}    
        {{- for attribute in allAttributes ~}}
            {{- if attribute.Type == "Nuid" }}
		entity.Ensure{{attribute.Name}}();		    
		    {{- else if attribute.Type == "ReferenceNumber"; awaiting = true }}
        var nextSequence{{attribute.Name}} =  await _repository.GetSequenceNextValueAsync(Nox.Solution.NoxCodeGenConventions.GetDatabaseSequenceName("{{entity.Name}}", "{{attribute.Name}}"));
        entity.Ensure{{attribute.Name}}(nextSequence{{attribute.Name}},{{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.{{attribute.Name}}TypeOptions);
            {{- end }}
		{{- end }}
        
        {{- for relationship in entity.OwnedRelationships }}
        {{- relationshipName = GetNavigationPropertyName entity relationship }}
            {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
        createDto.{{relationshipName}}?.ForEach(async dto =>
        {
            var {{ToLowerFirstChar relationship.Entity}} = await {{relationship.Entity}}Factory.CreateEntityAsync(dto, cultureCode);
            entity.CreateRefTo{{relationshipName}}({{ToLowerFirstChar relationship.Entity}});
        });
            {{- else}}
        if (createDto.{{relationshipName}} is not null)
        {
            var {{ToLowerFirstChar relationship.Entity}} = await {{relationship.Entity}}Factory.CreateEntityAsync(createDto.{{relationshipName}}, cultureCode);
            entity.CreateRefTo{{relationshipName}}({{ToLowerFirstChar relationship.Entity}});
        }
            {{-end}}
        {{- end }}        
        {{if awaiting}}return entity;{{else}}return await Task.FromResult(entity);{{- end }}
    }

    private async Task UpdateEntityInternalAsync({{entity.Name}}Entity entity, {{entityUpdateDto}} updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        {{- for attribute in entity.Attributes }}
            {{- if !IsNoxTypeUpdatable attribute.Type -}}
                {{ continue; }}
            {{- end}}
        {{ if attribute.IsLocalized }}if(IsDefaultCultureCode(cultureCode)) {{ end }}
        {{- if attribute.IsRequired -}}
        exceptionCollector.Collect("{{attribute.Name}}",() => entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(updateDto.{{attribute.Name}}
            {{- if IsNoxTypeSimpleType attribute.Type -}}.NonNullValue<{{SinglePrimitiveTypeForKey attribute}}>()
            {{- else -}}.NonNullValue<{{attribute.Type}}Dto>()
            {{- end}}));
        {{- else -}}
        if(updateDto.{{attribute.Name}} is null)
        {
             entity.{{attribute.Name}} = null;
        }
        else
        {
            exceptionCollector.Collect("{{attribute.Name}}",() =>entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(updateDto.{{attribute.Name}}
            {{- if IsNoxTypeSimpleType attribute.Type -}}.ToValueFromNonNull<{{SinglePrimitiveTypeForKey attribute}}>()
            {{- else -}}.ToValueFromNonNull<{{attribute.Type}}Dto>()
            {{- end}}));
        }      
        {{- end }}
        {{- end }}

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);

        {{- for key in entity.Keys ~}}
		    {{- if key.Type == "Nuid" }}
		entity.Ensure{{key.Name}}();
		    {{- end }}
		{{- end }}
        
        {{- if (entity.OwnedRelationships | array.size) > 0 }}
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);    
        {{- else }}
        await Task.CompletedTask;
		{{- end }}
    }

    private void PartialUpdateEntityInternal({{entity.Name}}Entity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        {{- for attribute in entity.Attributes }}
            {{- if !IsNoxTypeUpdatable attribute.Type -}}
                {{ continue; }}
            {{- end}}

        if ({{- if attribute.IsLocalized }}IsDefaultCultureCode(cultureCode) && {{ end -}} updatedProperties.TryGetValue("{{attribute.Name}}", out var {{attribute.Name}}UpdateValue))
        {
            {{- if attribute.IsRequired }}
            ArgumentNullException.ThrowIfNull({{attribute.Name}}UpdateValue, "Attribute '{{attribute.Name}}' can't be null.");            
            {{- else }}
            if ({{attribute.Name}}UpdateValue == null) { entity.{{attribute.Name}} = null; }
            else
            {{- end }}
            {
                {{- if IsNoxTypeSimpleType attribute.Type }}
                exceptionCollector.Collect("{{attribute.Name}}",() =>entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}({{attribute.Name}}UpdateValue));
                {{- else }}
                var entityToUpdate = entity.{{attribute.Name}} is null ? new {{attribute.Type}}Dto() : entity.{{attribute.Name}}.ToDto();
                {{attribute.Type}}Dto.UpdateFromDictionary(entityToUpdate, {{attribute.Name}}UpdateValue);
                exceptionCollector.Collect("{{attribute.Name}}",() =>entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(entityToUpdate));
                {{- end }}
            }
        }
        {{- end }}
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);

        {{- for key in entity.Keys ~}}
		    {{- if key.Type == "Nuid" }}
		entity.Ensure{{key.Name}}();
		    {{- end }}
		{{- end }}
    }

    {{- if entity.IsLocalized }}
    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
    {{- end }}

    {{- if (entity.OwnedRelationships | array.size) > 0 }}

	private async Task UpdateOwnedEntitiesAsync({{entity.Name}}Entity entity, {{entityUpdateDto}} updateDto, Nox.Types.CultureCode cultureCode)
	{
		{{- for ownedRelationship in entity.OwnedRelationships }}
			{{- navigationName = GetNavigationPropertyName entity ownedRelationship }}
			{{- key = ownedRelationship.Related.Entity.Keys | array.first }}
        
        {{- if ownedRelationship.WithSingleEntity }}
		if(updateDto.{{navigationName}} is null)
        {
            if(entity.{{navigationName}} is not null) 
                _repository.DeleteOwned(entity.{{navigationName}});
        {{- else }}
        if(!updateDto.{{navigationName}}.Any())
        { 
            _repository.DeleteOwned(entity.{{navigationName}});
        {{- end }}
			entity.DeleteAllRefTo{{navigationName}}();
        }
		else
		{
			{{- if ownedRelationship.WithSingleEntity }}
            if(entity.{{navigationName}} is not null)
                await {{ownedRelationship.Entity}}Factory.UpdateEntityAsync(entity.{{navigationName}}, updateDto.{{navigationName}}, cultureCode);
            else
			    entity.CreateRefTo{{navigationName}}(await {{ownedRelationship.Entity}}Factory.CreateEntityAsync(updateDto.{{navigationName}}, cultureCode));
			{{- else # WithMultiEntity }}
			var updated{{navigationName}} = new List<{{codeGeneratorState.DomainNameSpace}}.{{ownedRelationship.Entity}}>();
			foreach(var ownedUpsertDto in updateDto.{{navigationName}})
			{
				if(ownedUpsertDto.{{key.Name}} is null)
                {
                    var ownedEntity = await {{ownedRelationship.Entity}}Factory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updated{{navigationName}}.Add(ownedEntity);
                }
				else
				{
					var key = {{codeGeneratorState.DomainNameSpace}}.{{ownedRelationship.Entity}}Metadata.Create{{key.Name}}(ownedUpsertDto.{{key.Name}}.NonNullValue<{{keyType key}}>());
					var ownedEntity = entity.{{navigationName}}.FirstOrDefault(x => x.{{key.Name}} == key);
					if(ownedEntity is null)
						{{- if !IsNoxTypeCreatable key.Type }}
						throw new RelatedEntityNotFoundException("{{navigationName}}.{{key.Name}}", key.ToString());
                        {{- else }}
						updated{{navigationName}}.Add(await {{ownedRelationship.Entity}}Factory.CreateEntityAsync(ownedUpsertDto, cultureCode));
						{{- end }}
					else
					{
						await {{ownedRelationship.Entity}}Factory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updated{{navigationName}}.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<{{codeGeneratorState.DomainNameSpace}}.{{ownedRelationship.Entity}}>(
                entity.{{navigationName}}.Where(x => !updated{{navigationName}}.Exists(upd => upd.{{key.Name}} == x.{{key.Name}})).ToList());
			entity.UpdateRefTo{{navigationName}}(updated{{navigationName}});
			{{- end }}
		}
		{{- end }}
	}
	{{- end }}
}