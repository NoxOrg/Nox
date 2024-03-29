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
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using Dto = {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;

public partial record Create{{entity.Name}}Command({{entity.Name}}CreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<{{entity.Name}}KeyDto>;

internal partial class Create{{entity.Name}}CommandHandler : Create{{entity.Name}}CommandHandlerBase
{
	public Create{{entity.Name}}CommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		{{- for relatedEntity in relatedEntities }}
		IEntityFactory<{{codeGenConventions.DomainNameSpace}}.{{relatedEntity}}, {{relatedEntity}}CreateDto, {{relatedEntity}}UpdateDto> {{fieldFactoryName relatedEntity}},
		{{- end }}
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory)
		: base(repository, noxSolution, {{- for relatedEntity in relatedEntities}}{{fieldFactoryName relatedEntity}}, {{end}}entityFactory)
	{
	}
}


internal abstract class Create{{entity.Name}}CommandHandlerBase : CommandBase<Create{{entity.Name}}Command,{{entity.Name}}Entity>, IRequestHandler <Create{{entity.Name}}Command, {{entity.Name}}KeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> EntityFactory;
	
	
	{{- for relatedEntity in relatedEntities }}
	protected readonly IEntityFactory<{{codeGenConventions.DomainNameSpace}}.{{relatedEntity}}, {{relatedEntity}}CreateDto, {{relatedEntity}}UpdateDto> {{fieldFactoryName relatedEntity}};
	{{- end }}

	protected Create{{entity.Name}}CommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		{{- for relatedEntity in relatedEntities }}
		IEntityFactory<{{codeGenConventions.DomainNameSpace}}.{{relatedEntity}}, {{relatedEntity}}CreateDto, {{relatedEntity}}UpdateDto> {{fieldFactoryName relatedEntity}},
		{{- end }}
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		{{- for relatedEntity in relatedEntities }}
		this.{{fieldFactoryName relatedEntity}} = {{fieldFactoryName relatedEntity}};
		{{- end }}
	}

	public virtual async Task<{{entity.Name}}KeyDto> Handle(Create{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);

	{{- for relationship in entity.Relationships }}
		{{- relationshipName = GetNavigationPropertyName entity relationship }}
		{{- if relationship.WithSingleEntity }}
		if(request.EntityDto.{{relationshipName}}Id is not null)
		{
			{{- relatedEntity =  relationship.Related.Entity }}
			{{- if (array.size relatedEntity.Keys) == 1 }}

			{{- key = array.first relatedEntity.Keys }}
			var relatedKey = Dto.{{relatedEntity.Name}}Metadata.Create{{key.Name}}(request.EntityDto.{{relationshipName}}Id.NonNullValue<{{relationship.ForeignKeyPrimitiveType}}>());
			var relatedEntity = await Repository.FindAsync<{{codeGenConventions.DomainNameSpace}}.{{relatedEntity.Name}}>(relatedKey);
			
			{{- else }}

			{{- for key in relatedEntity.Keys }}
			var relatedKey{{key.Name}} = Dto.{{relatedEntity.Name}}Metadata.Create{{key.Name}}request.EntityDto.{{relationshipName}}Id!.key{{key.Name}});
			{{- end }}
			var relatedEntity = await Repository.FindAsync<{{codeGenConventions.DomainNameSpace}}.{{relatedEntity.Name}}>({{relatedEntity.Keys | array.map "Name" | keysQuery}});
			
			{{- end }}
			if(relatedEntity is not null)
				entityToCreate.CreateRefTo{{relationshipName}}(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("{{relationshipName}}", request.EntityDto.{{relationshipName}}Id.NonNullValue<{{relationship.ForeignKeyPrimitiveType}}>().ToString());
		}
		else if(request.EntityDto.{{relationshipName}} is not null)
		{
			var relatedEntity = await {{fieldFactoryName relationship.Entity}}.CreateEntityAsync(request.EntityDto.{{relationshipName}}, request.CultureCode);
			entityToCreate.CreateRefTo{{relationshipName}}(relatedEntity);
		}
		{{- else}}
		if(request.EntityDto.{{relationshipName}}Id.Any())
		{
			{{- relatedEntity =  relationship.Related.Entity }}
			{{- key = array.first relatedEntity.Keys }}
			foreach(var relatedId in request.EntityDto.{{relationshipName}}Id)
			{
				var relatedKey = Dto.{{relatedEntity.Name}}Metadata.Create{{key.Name}}(relatedId);
				var relatedEntity = await Repository.FindAsync<{{codeGenConventions.DomainNameSpace}}.{{relatedEntity.Name}}>(relatedKey);

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
				var relatedEntity = await {{fieldFactoryName relationship.Entity}}.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefTo{{relationshipName}}(relatedEntity);
			}
		}
		{{-end}}
	{{- end }}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<{{codeGenConventions.DomainNameSpace}}.{{entity.Name}}>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new {{entity.Name}}KeyDto({{primaryKeysQuery}});
	}
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