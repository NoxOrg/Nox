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

using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public record Create{{entity.Name}}Command({{entity.Name}}CreateDto EntityDto, Nox.Types.CultureCode {{codeGeneratorState.LocalizationCultureField}}) : IRequest<{{entity.Name}}KeyDto>;

internal partial class Create{{entity.Name}}CommandHandler : Create{{entity.Name}}CommandHandlerBase
{
	public Create{{entity.Name}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		{{- for relatedEntity in relatedEntities }}
		IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{relatedEntity}}, {{relatedEntity}}CreateDto, {{relatedEntity}}UpdateDto> {{fieldFactoryName relatedEntity}},
		{{- end }}
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory{{if entity.IsLocalized }},
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> entityLocalizedFactory{{ end -}})
		: base(dbContext, noxSolution, {{- for relatedEntity in relatedEntities}}{{fieldFactoryName relatedEntity}}, {{end}}entityFactory{{- if entity.IsLocalized }}, entityLocalizedFactory{{ end -}})
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
	{{- for relatedEntity in relatedEntities }}
	protected readonly IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{relatedEntity}}, {{relatedEntity}}CreateDto, {{relatedEntity}}UpdateDto> {{fieldFactoryName relatedEntity}};
	{{- end }}

	public Create{{entity.Name}}CommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		{{- for relatedEntity in relatedEntities }}
		IEntityFactory<{{codeGeneratorState.DomainNameSpace}}.{{relatedEntity}}, {{relatedEntity}}CreateDto, {{relatedEntity}}UpdateDto> {{fieldFactoryName relatedEntity}},
		{{- end }}
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory{{if entity.IsLocalized }},
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> entityLocalizedFactory{{ end -}})
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		{{- for relatedEntity in relatedEntities }}
		this.{{fieldFactoryName relatedEntity}} = {{fieldFactoryName relatedEntity}};
		{{- end }}
		{{- if entity.IsLocalized }} 
		EntityLocalizedFactory = entityLocalizedFactory;
		{{- end }}
	}

	public virtual async Task<{{entity.Name}}KeyDto> Handle(Create{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

	{{- for relationship in entity.Relationships }}
		{{- if relationship.WithSingleEntity }}
		if(request.EntityDto.{{relationship.Name}}Id is not null)
		{
			{{- relatedEntity =  relationship.Related.Entity }}
			{{- if (array.size relatedEntity.Keys) == 1 }}

			{{- key = array.first relatedEntity.Keys }}
			var relatedKey = {{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}Metadata.Create{{key.Name}}(request.EntityDto.{{relationship.Name}}Id.NonNullValue<{{relationship.ForeignKeyPrimitiveType}}>());
			var relatedEntity = await DbContext.{{relatedEntity.PluralName}}.FindAsync(relatedKey);
			
			{{- else }}

			{{- for key in relatedEntity.Keys }}
			var relatedKey{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}Metadata.Create{{key.Name}}request.EntityDto.{{relationship.Name}}Id!.key{{key.Name}});
			{{- end }}
			var relatedEntity = await DbContext.{{relatedEntity.PluralName}}.FindAsync({{relatedEntity.Keys | array.map "Name" | keysQuery}});
			
			{{- end }}
			if(relatedEntity is not null)
				entityToCreate.CreateRefTo{{relationship.Name}}(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("{{relationship.Name}}", request.EntityDto.{{relationship.Name}}Id.NonNullValue<{{relationship.ForeignKeyPrimitiveType}}>().ToString());
		}
		else if(request.EntityDto.{{relationship.Name}} is not null)
		{
			var relatedEntity = {{fieldFactoryName relationship.Entity}}.CreateEntity(request.EntityDto.{{relationship.Name}});
			entityToCreate.CreateRefTo{{relationship.Name}}(relatedEntity);
		}
		{{- else}}
		foreach(var relatedCreateDto in request.EntityDto.{{relationship.Name}})
		{
			var relatedEntity = {{fieldFactoryName relationship.Entity}}.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefTo{{relationship.Name}}(relatedEntity);
		}
		{{-end}}
	{{- end }}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.{{entity.PluralName}}.Add(entityToCreate);
		{{- if entity.IsLocalized }}
		var entityLocalizedToCreate = EntityLocalizedFactory.CreateLocalizedEntity(entityToCreate, request.{{codeGeneratorState.LocalizationCultureField}});
		DbContext.{{entity.PluralName}}Localized.Add(entityLocalizedToCreate);
		{{- end }}
		await DbContext.SaveChangesAsync();
		return new {{entity.Name}}KeyDto({{primaryKeysQuery}});
	}
}