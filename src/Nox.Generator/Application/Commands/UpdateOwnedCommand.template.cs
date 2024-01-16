{{- relationshipName = GetNavigationPropertyName parent relationship }}﻿
{{- func keyType(key)
   ret (key.Type == "EntityId") ? (SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity) : (SinglePrimitiveTypeForKey key)
end -}}
{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = ("{" + prefix + name + ".ToString()}")
	ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
end -}}
﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using {{codeGenConventions.PersistenceNameSpace}};
using {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using Dto = {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}};
using {{parent.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{parent.Name}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;

public partial record Update{{relationshipName}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, {{entity.Name}}UpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <{{entity.Name}}KeyDto>;

internal partial class Update{{relationshipName}}For{{parent.Name}}CommandHandler : Update{{relationshipName}}For{{parent.Name}}CommandHandlerBase
{
	public Update{{relationshipName}}For{{parent.Name}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class Update{{relationshipName}}For{{parent.Name}}CommandHandlerBase : CommandBase<Update{{relationshipName}}For{{parent.Name}}Command, {{entity.Name}}Entity>, IRequestHandler <Update{{relationshipName}}For{{parent.Name}}Command, {{entity.Name}}KeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> _entityFactory;

	protected Update{{relationshipName}}For{{parent.Name}}CommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<{{entity.Name}}KeyDto> Handle(Update{{relationshipName}}For{{parent.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		{{- for key in parent.Keys }}
		var key{{key.Name}} = Dto.{{parent.Name}}Metadata.Create{{key.Name}}(request.ParentKeyDto.key{{key.Name}});
		{{- end }}
		var parentEntity = await _dbContext.{{parent.PluralName}}.FindAsync({{parentKeysFindQuery}});
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("{{parent.Name}}",  $"{{keysToString parent.Keys}}");
		}

		{{- if relationship.WithSingleEntity }}
		await _dbContext.Entry(parentEntity).Reference(e => e.{{relationshipName}}).LoadAsync(cancellationToken);
		var entity = parentEntity.{{relationshipName}};
		if (entity is null)
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		else
			await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		{{- else }}

		{{- key = entity.Keys | array.first }}
		await _dbContext.Entry(parentEntity).Collection(p => p.{{relationshipName}}).LoadAsync(cancellationToken);
		
		{{entity.Name}}Entity? entity;
		if(request.EntityDto.{{key.Name}} is null)
		{
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		}
		else
		{
			var owned{{key.Name}} =Dto.{{entity.Name}}Metadata.Create{{key.Name}}(request.EntityDto.{{key.Name}}.NonNullValue<{{keyType key}}>());
			entity = parentEntity.{{relationshipName}}.SingleOrDefault(x => x.{{key.Name}} == owned{{key.Name}});
			if (entity is null)
				{{- if !(IsNoxTypeCreatable key.Type) }}
				throw new EntityNotFoundException("{{entity.Name}}",  $"{{keysToString entity.Keys 'owned'}}");
				{{- else }}
				entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
				{{- end }}
			else
				await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		}

		{{- end }}

		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity!);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		
		var result = await _dbContext.SaveChangesAsync();

		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}
	
	private async Task<{{entity.Name}}Entity> CreateEntityAsync({{entity.Name}}UpsertDto upsertDto, {{parent.Name}}Entity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefTo{{relationshipName}}(entity);
		return entity;
	}
}

{{- if (entity.Keys | array.size) > 0 }}

public class Update{{relationshipName}}For{{parent.Name}}Validator : AbstractValidator<Update{{relationshipName}}For{{parent.Name}}Command>
{
    public Update{{relationshipName}}For{{parent.Name}}Validator()
    {
		{{- for key in entity.Keys }}
			{{- if key.Type == "Guid" }} {{ continue; }}
			{{- else if IsNoxTypeCreatable key.Type }}		
		RuleFor(x => x.EntityDto.{{key.Name}}).NotNull().WithMessage("{{key.Name}} is required.");
			{{- end }}
        {{- end }}
    }
}
{{- end }}