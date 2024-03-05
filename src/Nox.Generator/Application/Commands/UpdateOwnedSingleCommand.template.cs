﻿{{- relationshipName = GetNavigationPropertyName parent relationship }}﻿
{{- func keyType(key)
   ret (key.Type == "EntityId") ? (SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity) : (SinglePrimitiveTypeForKey key)
end -}}
{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = (prefix + name)
	ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
end -}}
﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;

using {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using Dto = {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}};
using {{parent.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{parent.Name}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;

public partial record {{className}}({{parent.Name}}KeyDto ParentKeyDto, {{entity.Name}}UpsertDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <{{entity.Name}}KeyDto>;

internal partial class {{className}}Handler : {{className}}HandlerBase
{
	public {{className}}Handler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class {{className}}HandlerBase : CommandBase<{{className}}, {{entity.Name}}Entity>, IRequestHandler <{{className}}, {{entity.Name}}KeyDto>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> _entityFactory;

	protected {{className}}HandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<{{entity.Name}}KeyDto> Handle({{className}} request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>({{parent.Keys | array.size}});
		{{- for key in parent.Keys }}
		keys.Add(Dto.{{parent.Name}}Metadata.Create{{key.Name}}(request.ParentKeyDto.key{{key.Name}}));
		{{- end }}

		var parentEntity = await _repository.FindAndIncludeAsync<{{codeGenConventions.DomainNameSpace}}.{{parent.Name}}>(keys.ToArray(),e => e.{{relationshipName}}, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "{{parent.Name}}",  "{{keysToString parent.Keys}}");

		{{- if relationship.WithSingleEntity }}		
		var entity = parentEntity.{{relationshipName}};
		if (entity is null)
			entity = await CreateEntityAsync(request.EntityDto, parentEntity, request.CultureCode);
		else
			await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		{{- else }}
		var entity = parentEntity.{{relationshipName}}.Find(e => {{- for key in entity.Keys }} e.{{key.Name}} == Dto.{{entity.Name}}Metadata.Create{{key.Name}}(request.EntityDto.{{key.Name}}!{{if IsValueType (SinglePrimitiveTypeForKey key)}}.Value{{end}} {{if !(for.last)}} && {{end}}{{- end-}})); 
		EntityNotFoundException.ThrowIfNull(entity, "{{entity.Name}}",  "{{keysToString entity.Keys}}");
		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);
		{{- end }}

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entity!);
		await _repository.SaveChangesAsync();

		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}
	{{- if relationship.WithSingleEntity }}
	
	private async Task<{{entity.Name}}Entity> CreateEntityAsync({{entity.Name}}UpsertDto upsertDto, {{parent.Name}}Entity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateRefTo{{relationshipName}}(entity);
		return entity;
	}
	{{- end}}
}

{{- if (entity.Keys | array.size) > 0 }}

public class {{className}}Validator : AbstractValidator<{{className}}>
{
    public {{className}}Validator()
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