{{- relationshipName = GetNavigationPropertyName parent relationship }}﻿

{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = ("{" + prefix + name + ".ToString()}")
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

using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;
{{- if isSingleRelationship }}
public partial record PartialUpdate{{relationshipName}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <{{entity.Name}}KeyDto>;
{{ else }}
public partial record PartialUpdate{{relationshipName}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, {{entity.Name}}KeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <{{entity.Name}}KeyDto>;
{{- end }}
internal partial class PartialUpdate{{relationshipName}}For{{parent.Name}}CommandHandler: PartialUpdate{{relationshipName}}For{{parent.Name}}CommandHandlerBase
{
	public PartialUpdate{{relationshipName}}For{{parent.Name}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdate{{relationshipName}}For{{parent.Name}}CommandHandlerBase: CommandBase<PartialUpdate{{relationshipName}}For{{parent.Name}}Command, {{entity.Name}}Entity>, IRequestHandler <PartialUpdate{{relationshipName}}For{{parent.Name}}Command, {{entity.Name}}KeyDto>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> _entityFactory;
	
	protected PartialUpdate{{relationshipName}}For{{parent.Name}}CommandHandlerBase(
		AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}UpsertDto, {{entity.Name}}UpsertDto> entityFactory)
		: base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<{{entity.Name}}KeyDto> Handle(PartialUpdate{{relationshipName}}For{{parent.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		{{- for key in parent.Keys }}
		var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{parent.Name}}Metadata.Create{{key.Name}}(request.ParentKeyDto.key{{key.Name}});
		{{- end }}

		var parentEntity = await _dbContext.{{parent.PluralName}}.FindAsync({{parentKeysFindQuery}});
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("{{parent.Name}}",  $"{{parent.Keys | keysToString}}");
		}

		{{- if isSingleRelationship }}
		await _dbContext.Entry(parentEntity).Reference(e => e.{{relationshipName}}).LoadAsync(cancellationToken);
		var entity = parentEntity.{{relationshipName}};
		{{ else }}
		await _dbContext.Entry(parentEntity).Collection(p => p.{{relationshipName}}).LoadAsync(cancellationToken);
		{{- for key in entity.Keys }}
		var owned{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(request.EntityKeyDto.key{{key.Name}});
		{{- end }}
		var entity = parentEntity.{{relationshipName}}.SingleOrDefault(x => {{ownedKeysFindQuery}});
		{{- end }}
		if (entity == null)
		{
			{{- ownedKeysString = (entity.Keys.size > 0) ? ('$"' + (keysToString entity.Keys 'owned') + '"') : 'String.Empty' }}
			throw new EntityNotFoundException("{{parent.Name}}.{{relationshipName}}", {{ownedKeysString}});
		}

		await _entityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		_dbContext.Entry(entity).State = EntityState.Modified;
		
		var result = await _dbContext.SaveChangesAsync();

		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}
}