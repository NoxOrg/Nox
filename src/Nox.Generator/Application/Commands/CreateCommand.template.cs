{{- func fieldFactoryName
	ret ($0 + "Factory")
end -}}
{{- func relatedKeyName
	ret ("relatedKey" + $0)
end -}}
{{- func keysQuery(keyNames)	
	ret (keyNames | array.each @relatedKeyName | array.join ", ")
end -}}
﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
{{- if (entity.Persistence?.IsAudited ?? true)}}
using Nox.Abstractions;
{{- end}}
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using FluentValidation;
using Microsoft.Extensions.Logging;

using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public partial record Create{{entity.Name}}Command({{entity.Name}}CreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<{{entity.Name}}KeyDto>;

internal partial class Create{{entity.Name}}CommandHandler : Create{{entity.Name}}CommandHandlerBase
{
	public Create{{entity.Name}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		{{- for relatedEntity in relatedEntities }}
		IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{relatedEntity}}, {{relatedEntity}}CreateDto, {{relatedEntity}}UpdateDto> {{fieldFactoryName relatedEntity}},
		{{- end }}
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory{{if entity.IsLocalized }},
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> entityLocalizedFactory{{ end -}}{{- for relationship in entity.OwnedRelationships }}{{- if relationship.Related.Entity.IsLocalized }},
		IEntityLocalizedFactory<{{relationship.Related.Entity.Name}}Localized, {{codeGeneratorState.DomainNameSpace}}.{{relationship.Related.Entity.Name}}, {{relationship.Related.Entity.Name}}UpsertDto> {{ relationship.Related.Entity.Name}}LocalizedFactory{{- end -}}{{- end -}})
		: base(dbContext, noxSolution, {{- for relatedEntity in relatedEntities}}{{fieldFactoryName relatedEntity}}, {{end}}entityFactory{{- if entity.IsLocalized }}, entityLocalizedFactory{{ end -}}{{- for relationship in entity.OwnedRelationships }}{{- if relationship.Related.Entity.IsLocalized }}, {{ relationship.Related.Entity.Name}}LocalizedFactory{{- end -}}{{- end -}})
	{
	}
}


internal abstract class Create{{entity.Name}}CommandHandlerBase : CommandBase<Create{{entity.Name}}Command,{{entity.Name}}Entity>, IRequestHandler <Create{{entity.Name}}Command, {{entity.Name}}KeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> EntityFactory;
	{{- if entity.IsLocalized }}
	protected readonly IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> EntityLocalizedFactory;
	{{- end -}}
	{{- for relationship in entity.OwnedRelationships }}
	{{- if relationship.Related.Entity.IsLocalized }}
	protected readonly IEntityLocalizedFactory<{{relationship.Related.Entity.Name}}Localized, {{codeGeneratorState.DomainNameSpace}}.{{relationship.Related.Entity.Name}}, {{relationship.Related.Entity.Name}}UpsertDto> {{ relationship.Related.Entity.Name}}LocalizedFactory;
	{{- end -}}
	{{- end -}}
	{{- for relatedEntity in relatedEntities }}
	protected readonly IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{relatedEntity}}, {{relatedEntity}}CreateDto, {{relatedEntity}}UpdateDto> {{fieldFactoryName relatedEntity}};
	{{- end }}

	protected Create{{entity.Name}}CommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		{{- for relatedEntity in relatedEntities }}
		IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{relatedEntity}}, {{relatedEntity}}CreateDto, {{relatedEntity}}UpdateDto> {{fieldFactoryName relatedEntity}},
		{{- end }}
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory{{if entity.IsLocalized }},
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> entityLocalizedFactory{{ end -}}{{- for relationship in entity.OwnedRelationships }}{{- if relationship.Related.Entity.IsLocalized }},
		IEntityLocalizedFactory<{{relationship.Related.Entity.Name}}Localized, {{codeGeneratorState.DomainNameSpace}}.{{relationship.Related.Entity.Name}}, {{relationship.Related.Entity.Name}}UpsertDto> {{ relationship.Related.Entity.Name}}LocalizedFactory{{- end -}}{{- end -}})
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		{{- if entity.IsLocalized }} 
		EntityLocalizedFactory = entityLocalizedFactory;
		{{- end }}
		{{- for relationship in entity.OwnedRelationships }}
		{{- if relationship.Related.Entity.IsLocalized }}
		this.{{relationship.Related.Entity.Name}}LocalizedFactory = {{relationship.Related.Entity.Name}}LocalizedFactory;
		{{- end -}}
		{{- end }}
		{{- for relatedEntity in relatedEntities }}
		this.{{fieldFactoryName relatedEntity}} = {{fieldFactoryName relatedEntity}};
		{{- end }}
	}

	public virtual async Task<{{entity.Name}}KeyDto> Handle(Create{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto);

	{{- for relationship in entity.Relationships }}
		{{- relationshipName = GetNavigationPropertyName entity relationship }}
		{{- if relationship.WithSingleEntity }}
		if(request.EntityDto.{{relationshipName}}Id is not null)
		{
			{{- relatedEntity =  relationship.Related.Entity }}
			{{- if (array.size relatedEntity.Keys) == 1 }}

			{{- key = array.first relatedEntity.Keys }}
			var relatedKey = {{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}Metadata.Create{{key.Name}}(request.EntityDto.{{relationshipName}}Id.NonNullValue<{{relationship.ForeignKeyPrimitiveType}}>());
			var relatedEntity = await DbContext.{{relatedEntity.PluralName}}.FindAsync(relatedKey);
			
			{{- else }}

			{{- for key in relatedEntity.Keys }}
			var relatedKey{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}Metadata.Create{{key.Name}}request.EntityDto.{{relationshipName}}Id!.key{{key.Name}});
			{{- end }}
			var relatedEntity = await DbContext.{{relatedEntity.PluralName}}.FindAsync({{relatedEntity.Keys | array.map "Name" | keysQuery}});
			
			{{- end }}
			if(relatedEntity is not null)
				entityToCreate.CreateRefTo{{relationshipName}}(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("{{relationshipName}}", request.EntityDto.{{relationshipName}}Id.NonNullValue<{{relationship.ForeignKeyPrimitiveType}}>().ToString());
		}
		else if(request.EntityDto.{{relationshipName}} is not null)
		{
			var relatedEntity = await {{fieldFactoryName relationship.Entity}}.CreateEntityAsync(request.EntityDto.{{relationshipName}});
			entityToCreate.CreateRefTo{{relationshipName}}(relatedEntity);
		}
		{{- else}}
		if(request.EntityDto.{{relationshipName}}Id.Any())
		{
			{{- relatedEntity =  relationship.Related.Entity }}
			{{- key = array.first relatedEntity.Keys }}
			foreach(var relatedId in request.EntityDto.{{relationshipName}}Id)
			{
				var relatedKey = {{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}Metadata.Create{{key.Name}}(relatedId);
				var relatedEntity = await DbContext.{{relatedEntity.PluralName}}.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefTo{{relationshipName}}(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("{{relationshipName}}", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.{{relationshipName}})
			{
				var relatedEntity = await {{fieldFactoryName relationship.Entity}}.CreateEntityAsync(relatedCreateDto);
				entityToCreate.CreateRefTo{{relationshipName}}(relatedEntity);
			}
		}
		{{-end}}
	{{- end }}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.{{entity.PluralName}}.Add(entityToCreate);
		{{- if entity.IsLocalized || entity.HasLocalizedOwnedRelationships }}
        CreateLocalizations(entityToCreate, request.CultureCode);
		{{- end }}
		await DbContext.SaveChangesAsync();
		return new {{entity.Name}}KeyDto({{primaryKeysQuery}});
	}
	{{- if entity.IsLocalized || entity.HasLocalizedOwnedRelationships }}

	private void CreateLocalizations({{entity.Name}}Entity entity, Nox.Types.CultureCode cultureCode)
	{
		{{- if entity.IsLocalized }}
		Create{{entity.Name}}Localization(entity, cultureCode);
		{{- end}}
		{{- for relationship in entity.OwnedRelationships }}
		{{- if relationship.Related.Entity.IsLocalized }}
		{{- relationshipName = GetNavigationPropertyName entity relationship}}
        Create{{relationshipName}}Localization(entity.{{relationshipName}}, cultureCode);
		{{- end }}
		{{- end }}
	}
	{{- if entity.IsLocalized }}

	private void Create{{entity.Name}}Localization({{entity.Name}}Entity entity, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = EntityLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
		DbContext.{{entity.PluralName}}Localized.Add(entityLocalized);
	}	
	{{- end}}
	{{- for relationship in entity.OwnedRelationships }}
	{{- if relationship.Related.Entity.IsLocalized }}
	{{- relationshipName = GetNavigationPropertyName entity relationship}}
	{{- if relationship.Relationship == "ZeroOrOne" || relationship.Relationship == "ExactlyOne" }}
	
	private void Create{{relationshipName}}Localization({{codeGeneratorState.DomainNameSpace}}.{{relationship.Related.Entity.Name}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} entity, Nox.Types.CultureCode cultureCode)
	{
		{{- if relationship.Relationship == "ZeroOrOne"}}
		if (entity is null) return;
		{{- end}}
		var entityLocalized = {{relationship.Related.Entity.Name}}LocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
		DbContext.{{relationship.Related.Entity.PluralName}}Localized.Add(entityLocalized);
	}	
	{{else}}
	
	private void Create{{relationshipName}}Localization(List<{{codeGeneratorState.DomainNameSpace}}.{{relationship.Related.Entity.Name}}> entities, Nox.Types.CultureCode cultureCode)
	{
		var entitiesLocalized = entities.Select(entity => {{relationship.Related.Entity.Name}}LocalizedFactory.CreateLocalizedEntity(entity, cultureCode));
		DbContext.{{relationship.Related.Entity.PluralName}}Localized.AddRange(entitiesLocalized);
	}	
	{{- end}}
	{{- end}}
	{{- end}}
	{{- end}}
}

{{- if (entity.OwnedRelationships | array.size) > 0 }}

public class Create{{entity.Name}}Validator : AbstractValidator<Create{{entity.Name}}Command>
{
    public Create{{entity.Name}}Validator()
    {
		{{- for ownedRelationship in entity.OwnedRelationships }}
			{{- if ownedRelationship.WithMultiEntity }}
				{{- relationshipName = GetNavigationPropertyName entity ownedRelationship }}
				{{- key = ownedRelationship.Related.Entity.Keys | array.first }}
					{{- if key.Type == "Guid" }} {{ continue; }}
					{{- else if !IsNoxTypeCreatable key.Type }}
		RuleFor(x => x.EntityDto.{{relationshipName}})
			.Must(owned => owned.TrueForAll(x => x.{{key.Name}} == null))
			.WithMessage("{{relationshipName}}.{{key.Name}} must be null as it is auto generated.");
					{{- else }}
		RuleFor(x => x.EntityDto.{{relationshipName}})
			.Must(owned => owned.All(x => x.{{key.Name}} != null))
			.WithMessage("{{relationshipName}}.{{key.Name}} is required.");
					{{- end }}
			{{- end }}
        {{- end }}
    }
}
{{- end }}