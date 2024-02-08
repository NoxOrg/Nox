{{- relationshipName = GetNavigationPropertyName parent relationship }}﻿

{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = (prefix + name)
	ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
end -}}
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Domain;

using {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using Dto = {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;
{{- if isSingleRelationship }}
public partial record PartialUpdate{{relationshipName}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <{{entity.Name}}KeyDto>;
{{ else }}
public partial record PartialUpdate{{relationshipName}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, {{entity.Name}}KeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <{{entity.Name}}KeyDto>;
{{- end }}
internal partial class PartialUpdate{{relationshipName}}For{{parent.Name}}CommandHandler: PartialUpdate{{relationshipName}}For{{parent.Name}}CommandHandlerBase
{
	public PartialUpdate{{relationshipName}}For{{parent.Name}}CommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdate{{relationshipName}}For{{parent.Name}}CommandHandlerBase: CommandBase<PartialUpdate{{relationshipName}}For{{parent.Name}}Command, {{entity.Name}}Entity>, IRequestHandler <PartialUpdate{{relationshipName}}For{{parent.Name}}Command, {{entity.Name}}KeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> EntityFactory;
	
	protected PartialUpdate{{relationshipName}}For{{parent.Name}}CommandHandlerBase(
		IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<{{entity.Name}}KeyDto> Handle(PartialUpdate{{relationshipName}}For{{parent.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>({{parent.Keys | array.size}});
		{{- for key in parent.Keys }}
		keys.Add(Dto.{{parent.Name}}Metadata.Create{{key.Name}}(request.ParentKeyDto.key{{key.Name}}));
		{{- end }}

		var parentEntity = await Repository.FindAndIncludeAsync<{{codeGenConventions.DomainNameSpace}}.{{parent.Name}}>(keys.ToArray(),e => e.{{relationshipName}}, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("{{parent.Name}}",  "{{parent.Keys | keysToString}}");
		}

		{{- if isSingleRelationship }}
		var entity = parentEntity.{{relationshipName}};
		{{ else }}
		{{- for key in entity.Keys }}
		var owned{{key.Name}} = Dto.{{entity.Name}}Metadata.Create{{key.Name}}(request.EntityKeyDto.key{{key.Name}});
		{{- end }}
		var entity = parentEntity.{{relationshipName}}.SingleOrDefault(x => {{ownedKeysFindQuery}});
		{{- end }}
		if (entity == null)
		{
			{{- ownedKeysString = (entity.Keys.size > 0) ? ('$"' + (keysToString entity.Keys 'owned') + '"') : 'String.Empty' }}
			throw new EntityNotFoundException("{{parent.Name}}.{{relationshipName}}", {{ownedKeysString}});
		}

		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);
		await Repository.SaveChangesAsync();		

		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}
}