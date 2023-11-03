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
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public record Update{{entity.Name}}Command({{primaryKeys}}, {{entity.Name}}UpdateDto EntityDto, Nox.Types.CultureCode {{codeGeneratorState.LocalizationCultureField}}{{ if !entity.IsOwnedEntity}}, System.Guid? Etag{{end}}) : IRequest<{{entity.Name}}KeyDto?>;

internal partial class Update{{entity.Name}}CommandHandler : Update{{entity.Name}}CommandHandlerBase
{
	public Update{{entity.Name}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory{{if entity.IsLocalized }},
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> entityLocalizedFactory{{ end -}}) 
		: base(dbContext, noxSolution, entityFactory{{- if entity.IsLocalized }}, entityLocalizedFactory{{ end -}})
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

	public Update{{entity.Name}}CommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory{{if entity.IsLocalized }},
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> entityLocalizedFactory{{ end -}})
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
		{{- if entity.IsLocalized }} 
		_entityLocalizedFactory = entityLocalizedFactory;
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

	{{- for relationship in entity.Relationships }}
		{{- relatedEntity =  relationship.Related.Entity }}
		{{- key = array.first relatedEntity.Keys }}
		{{- if relationship.Relationship == "ZeroOrOne" }}

		if(request.EntityDto.{{relationship.Name}}Id is not null)
		{
			var {{ToLowerFirstChar relationship.Name}}Key = {{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}Metadata.Create{{key.Name}}(request.EntityDto.{{relationship.Name}}Id.NonNullValue<{{relationship.ForeignKeyPrimitiveType}}>());
			var {{ToLowerFirstChar relationship.Name}}Entity = await DbContext.{{relatedEntity.PluralName}}.FindAsync({{ToLowerFirstChar relationship.Name}}Key);
						
			if({{ToLowerFirstChar relationship.Name}}Entity is not null)
				entity.CreateRefTo{{relationship.Name}}({{ToLowerFirstChar relationship.Name}}Entity);
			else
				throw new RelatedEntityNotFoundException("{{relationship.Name}}", request.EntityDto.{{relationship.Name}}Id.NonNullValue<{{relationship.ForeignKeyPrimitiveType}}>().ToString());
		}
		else
		{
			entity.DeleteAllRefTo{{relationship.Name}}();
		}
		{{- else if relationship.Relationship == "ExactlyOne" }}

		var {{ToLowerFirstChar relationship.Name}}Key = {{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}Metadata.Create{{key.Name}}(request.EntityDto.{{relationship.Name}}Id);
		var {{ToLowerFirstChar relationship.Name}}Entity = await DbContext.{{relatedEntity.PluralName}}.FindAsync({{ToLowerFirstChar relationship.Name}}Key);
						
		if({{ToLowerFirstChar relationship.Name}}Entity is not null)
			entity.CreateRefTo{{relationship.Name}}({{ToLowerFirstChar relationship.Name}}Entity);
		else
			throw new RelatedEntityNotFoundException("{{relationship.Name}}", request.EntityDto.{{relationship.Name}}Id.ToString());
		{{- else }}

		await DbContext.Entry(entity).Collection(x => x.{{relationship.Name}}).LoadAsync();
		var {{ToLowerFirstChar relationship.Name}}Entities = new List<{{relationship.Entity}}>();
		foreach(var relatedEntityId in request.EntityDto.{{relationship.Name}}Id)
		{
			var relatedKey = {{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}Metadata.Create{{key.Name}}(relatedEntityId);
			var relatedEntity = await DbContext.{{relatedEntity.PluralName}}.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				{{ToLowerFirstChar relationship.Name}}Entities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("{{relationship.Name}}", relatedEntityId.ToString());
		}
		entity.UpdateRefTo{{relationship.Name}}({{ToLowerFirstChar relationship.Name}}Entities);
		{{-end}}
	{{- end }}

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);

		{{- if !entity.IsOwnedEntity }}
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		{{- end }}
		
		{{- if entity.IsLocalized }}
		await UpdateLocalizedEntityAsync(entity, request.EntityDto, request.CultureCode);
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
	{{- if entity.IsLocalized }}

	private async Task UpdateLocalizedEntityAsync({{entity.Name}}Entity entity, {{entity.Name}}UpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await DbContext.{{entity.PluralName}}Localized.FirstOrDefaultAsync(x => x.Id == entity.Id && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = _entityLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
			DbContext.{{entity.PluralName}}Localized.Add(entityLocalized);
		}
		else
		{
			DbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		_entityLocalizedFactory.UpdateLocalizedEntity(entityLocalized, updateDto, cultureCode);
	}
	{{- end }}
}