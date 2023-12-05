﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public partial record Update{{entity.Name}}Command({{primaryKeys}}, {{entity.Name}}UpdateDto EntityDto, Nox.Types.CultureCode {{codeGeneratorState.LocalizationCultureField}}{{ if !entity.IsOwnedEntity}}, System.Guid? Etag{{end}}) : IRequest<{{entity.Name}}KeyDto?>;

internal partial class Update{{entity.Name}}CommandHandler : Update{{entity.Name}}CommandHandlerBase
{
	public Update{{entity.Name}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory{{if entity.IsLocalized }},
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> entityLocalizedFactory{{ end -}}{{- for relationship in entity.OwnedRelationships }}{{- if relationship.Related.Entity.IsLocalized }},
		IEntityLocalizedFactory<{{relationship.Related.Entity.Name}}Localized, {{codeGeneratorState.DomainNameSpace}}.{{relationship.Related.Entity.Name}}, {{relationship.Related.Entity.Name}}UpsertDto> {{ relationship.Related.Entity.Name}}LocalizedFactory{{- end -}}{{- end -}})
		: base(dbContext, noxSolution, {{- for relatedEntity in relatedEntities}}{{fieldFactoryName relatedEntity}}, {{end}}entityFactory{{- if entity.IsLocalized }}, entityLocalizedFactory{{ end -}}{{- for relationship in entity.OwnedRelationships }}{{- if relationship.Related.Entity.IsLocalized }}, {{ relationship.Related.Entity.Name}}LocalizedFactory{{- end -}}{{- end -}})
	{
	}
}

internal abstract class Update{{entity.Name}}CommandHandlerBase : CommandBase<Update{{entity.Name}}Command, {{entity.Name}}Entity>, IRequestHandler<Update{{entity.Name}}Command, {{entity.Name}}KeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> _entityFactory;
	{{- if entity.IsLocalized }}
	private readonly IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> _entityLocalizedFactory;
	{{- end }}
	{{- for relationship in entity.OwnedRelationships }}
	{{- if relationship.Related.Entity.IsLocalized }}
	protected readonly IEntityLocalizedFactory<{{relationship.Related.Entity.Name}}Localized, {{codeGeneratorState.DomainNameSpace}}.{{relationship.Related.Entity.Name}}, {{relationship.Related.Entity.Name}}UpsertDto> {{ relationship.Related.Entity.Name}}LocalizedFactory;
	{{- end -}}
	{{- end }}

	protected Update{{entity.Name}}CommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory{{if entity.IsLocalized }},
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> entityLocalizedFactory{{ end -}}{{- for relationship in entity.OwnedRelationships }}{{- if relationship.Related.Entity.IsLocalized }},
		IEntityLocalizedFactory<{{relationship.Related.Entity.Name}}Localized, {{codeGeneratorState.DomainNameSpace}}.{{relationship.Related.Entity.Name}}, {{relationship.Related.Entity.Name}}UpsertDto> {{ relationship.Related.Entity.Name}}LocalizedFactory{{- end -}}{{- end -}})
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
		{{- if entity.IsLocalized }} 
		_entityLocalizedFactory = entityLocalizedFactory;
		{{- end }}
		{{- for relationship in entity.OwnedRelationships }}
		{{- if relationship.Related.Entity.IsLocalized }}
		this.{{relationship.Related.Entity.Name}}LocalizedFactory = {{relationship.Related.Entity.Name}}LocalizedFactory;
		{{- end -}}
		{{- end }}
	}

	public virtual async Task<{{entity.Name}}KeyDto?> Handle(Update{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		{{- for key in entity.Keys }}
		var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(request.key{{key.Name}});
		{{- end }}

		var entity = await DbContext.{{entity.PluralName}}.FindAsync({{primaryKeysFindQuery}});
		if (entity == null)
		{
			return null;
		}

		{{- for relationship in entity.OwnedRelationships }}
            {{- navigationName = GetNavigationPropertyName entity relationship }}
			{{- if relationship.WithSingleEntity }}
		await DbContext.Entry(entity).Reference(x => x.{{navigationName}}).LoadAsync();
			{{- else }}
		await DbContext.Entry(entity).Collection(x => x.{{navigationName}}).LoadAsync();
			{{- end }}
		{{- end }}

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);

		{{- if !entity.IsOwnedEntity }}
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		{{- end }}
		
		{{- if entity.IsLocalized || entity.HasLocalizedOwnedRelationships }}
		await UpdateLocalizationsAsync(entity, request.EntityDto, request.CultureCode);
		{{- end }}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}
	{{- if entity.IsLocalized || entity.HasLocalizedOwnedRelationships }}

	private async Task UpdateLocalizationsAsync({{entity.Name}}Entity entity, {{entity.Name}}UpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		{{- if entity.IsLocalized }}
		await Update{{entity.Name}}LocalizationAsync(entity, updateDto, cultureCode);
		{{- end}}
		{{- for relationship in entity.OwnedRelationships }}
		{{- if relationship.Related.Entity.IsLocalized }}
		{{- relationshipName = GetNavigationPropertyName entity relationship}}
        await Update{{relationshipName}}LocalizationAsync(entity.{{relationshipName}}, updateDto.{{relationshipName}}, cultureCode);
		{{- end }}
		{{- end }}
	}
	{{- if entity.IsLocalized }}

	private async Task Update{{entity.Name}}LocalizationAsync({{entity.Name}}Entity entity, {{entity.Name}}UpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await DbContext.{{entity.PluralName}}Localized.FirstOrDefaultAsync(x => x.{{entity.Keys[0].Name}} == entity.{{entity.Keys[0].Name}} && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = _entityLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
			DbContext.{{entity.PluralName}}Localized.Add(entityLocalized);
		}
		else
		{
			DbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		_entityLocalizedFactory.UpdateLocalizedEntity(entityLocalized, updateDto);
	}	
	{{- end}}
	{{- for relationship in entity.OwnedRelationships }}
	{{- if relationship.Related.Entity.IsLocalized }}
	{{- relationshipName = GetNavigationPropertyName entity relationship}}
	{{- if relationship.Relationship == "ZeroOrOne" || relationship.Relationship == "ExactlyOne" }}
	
	private async Task Update{{relationshipName}}LocalizationAsync({{codeGeneratorState.DomainNameSpace}}.{{relationship.Related.Entity.Name}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} entity, {{codeGeneratorState.DtoNameSpace}}.{{relationship.Related.Entity.Name}}UpsertDto{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} updateDto, Nox.Types.CultureCode cultureCode)
	{
		{{- if relationship.Relationship == "ZeroOrOne"}}
		if(entity is null || updateDto is null) return;

		{{- end}}
		var entityLocalized = await DbContext.{{relationship.Related.Entity.PluralName}}Localized.FirstOrDefaultAsync(x => x.{{entity.Name}}{{entity.Keys[0].Name}} == entity.{{entity.Name}}{{entity.Keys[0].Name}} && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = {{relationship.Related.Entity.Name}}LocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
			DbContext.{{relationship.Related.Entity.PluralName}}Localized.Add(entityLocalized);
		}
		else
		{
			DbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		{{relationship.Related.Entity.Name}}LocalizedFactory.UpdateLocalizedEntity(entityLocalized, updateDto);
	}	
	{{else}}
	
	private async Task Update{{relationshipName}}LocalizationAsync(List<{{codeGeneratorState.DomainNameSpace}}.{{relationship.Related.Entity.Name}}> entities, List<{{codeGeneratorState.DtoNameSpace}}.{{relationship.Related.Entity.Name}}UpsertDto> updateDtos, Nox.Types.CultureCode cultureCode)
	{
		for(int i = 0; i < updateDtos.Count; i++)
		{
			var updateDto = updateDtos[i];
			var entity = entities.SingleOrDefault(e => e.{{relationship.Related.Entity.Keys[0].Name}}.Value == updateDto.{{relationship.Related.Entity.Keys[0].Name}});
			if (entity is null) continue;

			await Update{{relationshipName}}LocalizationAsync(entity, updateDto, cultureCode);
		}
	}

	private async Task Update{{relationshipName}}LocalizationAsync({{codeGeneratorState.DomainNameSpace}}.{{relationship.Related.Entity.Name}} entity, {{codeGeneratorState.DtoNameSpace}}.{{relationship.Related.Entity.Name}}UpsertDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await DbContext.{{relationship.Related.Entity.PluralName}}Localized.FirstOrDefaultAsync(x => x.{{relationship.Related.Entity.Keys[0].Name}} == entity.{{relationship.Related.Entity.Keys[0].Name}} && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = {{relationship.Related.Entity.Name}}LocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
			DbContext.{{relationship.Related.Entity.PluralName}}Localized.Add(entityLocalized);
		}
		else
		{
			DbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		{{relationship.Related.Entity.Name}}LocalizedFactory.UpdateLocalizedEntity(entityLocalized, updateDto);
	}
	{{- end}}
	{{- end}}
	{{- end}}
	{{- end}}
}

{{- if (entity.OwnedRelationships | array.size) > 0 }}

public class Update{{entity.Name}}Validator : AbstractValidator<Update{{entity.Name}}Command>
{
    public Update{{entity.Name}}Validator()
    {
		{{- for ownedRelationship in entity.OwnedRelationships }}
			{{- if ownedRelationship.WithMultiEntity }}
				{{- relationshipName = GetNavigationPropertyName entity ownedRelationship }}
				{{- key = ownedRelationship.Related.Entity.Keys | array.first }}
					{{- if key.Type == "Guid" }} {{ continue; }}
					{{- else if IsNoxTypeCreatable key.Type }}
		RuleFor(x => x.EntityDto.{{relationshipName}})
			.ForEach(item => 
			{
				item.Must(owned => owned.{{key.Name}} != null)
					.WithMessage((item, index) => $"{{relationshipName}}[{index}].{{key.Name}} is required.");
			});
					{{- end }}
			{{- end }}
        {{- end }}
    }
}
{{- end }}