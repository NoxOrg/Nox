{{-entityUpdateDto = entity.IsOwnedEntity ? (entity.Name + "UpsertDto") : (entity.Name + "UpdateDto") -}}
// Generated

#nullable enable

using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Types;
using Nox.Domain;
using Microsoft.EntityFrameworkCore;

using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using Dto = {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{codeGenConventions.DomainNameSpace}};
using {{entity.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Factories;

internal partial class {{className}} : {{className}}Base
{
    public {{className}}(IRepository repository):base(repository)
    {
    }
}

internal abstract class {{className}}Base : IEntityLocalizedFactory<{{localizedEntityName}}, {{entity.Name}}Entity, {{entityUpdateDto}}>
{
    protected readonly IRepository Repository;

    protected {{className}}Base(IRepository repository)
    {
        Repository = repository;
    }

    public virtual {{localizedEntityName}} CreateLocalizedEntity({{entity.Name}}Entity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = CreateInternal(entity, cultureCode, copyEntityAttributes);
        return localizedEntity;
    }
   

    public virtual async Task UpdateLocalizedEntityAsync({{entity.Name}}Entity entity, {{entityUpdateDto}} updateDto, CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<{{localizedEntityName}}>().Where(x =>{{for key in entityKeys }} x.{{key.Name}} == entity.{{key.Name}} &&{{end}} x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        
        {{- for attribute in entityLocalizedAttributes }}
        entityLocalized.{{attribute.Name}} = updateDto.{{attribute.Name}} == null
            ? null
            : Dto.{{entity.Name}}Metadata.Create{{attribute.Name}}(updateDto.{{attribute.Name}}
        {{- if IsNoxTypeSimpleType attribute.Type -}}.ToValueFromNonNull<{{SinglePrimitiveTypeForKey attribute}}>()
        {{- else -}}.ToValueFromNonNull<{{attribute.Type}}Dto>()
        {{- end}});
        {{- end }}
    }

    public virtual async Task PartialUpdateLocalizedEntityAsync({{entity.Name}}Entity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        var entityLocalized = await Repository.Query<{{localizedEntityName}}>().Where(x =>{{for key in entityKeys }} x.{{key.Name}} == entity.{{key.Name}} &&{{end}} x.CultureCode == cultureCode).FirstOrDefaultAsync();
        if (entityLocalized is null)
        {
            entityLocalized = CreateLocalizedEntity(entity, cultureCode);
        }
        
        {{- for attribute in entityLocalizedAttributes }}
        {{- if !IsNoxTypeReadable attribute.Type || attribute.Type == "Formula" -}}
        {{ continue; }}
        {{- end}}
        if (updatedProperties.TryGetValue("{{attribute.Name}}", out var {{attribute.Name}}UpdateValue))
        {
            entityLocalized.{{attribute.Name}} = {{attribute.Name}}UpdateValue == null
                ? null
                : Dto.{{entity.Name}}Metadata.Create{{attribute.Name}}({{attribute.Name}}UpdateValue);
        }
        {{- end }}
    }

    private {{localizedEntityName}} CreateInternal({{entity.Name}}Entity entity, CultureCode cultureCode, bool copyEntityAttributes = true)
    {
        var localizedEntity = new {{localizedEntityName}}
        {
            {{entity.Name}} = entity,
            {{codeGenConventions.LocalizationCultureField}} = cultureCode,
        };

        if (copyEntityAttributes)
        { 
            {{- for attribute in entityLocalizedAttributes }}
            localizedEntity.{{attribute.Name}} = entity.{{attribute.Name}};
            {{- end }}
        }
        entity.CreateRefToLocalized{{entity.PluralName}}(localizedEntity);
        return localizedEntity;
    }
}