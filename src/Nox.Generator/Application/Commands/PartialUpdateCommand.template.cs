﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public record PartialUpdate{{entity.Name}}Command({{primaryKeys}}, Dictionary<string, dynamic> UpdatedProperties{{ if !entity.IsOwnedEntity }}, System.Guid? Etag{{end}}) : IRequest <{{entity.Name}}KeyDto?>;

internal class PartialUpdate{{entity.Name}}CommandHandler: PartialUpdate{{entity.Name}}CommandHandlerBase
{
	public PartialUpdate{{entity.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdate{{entity.Name}}CommandHandlerBase: CommandBase<PartialUpdate{{entity.Name}}Command, {{entity.Name}}>, IRequestHandler<PartialUpdate{{entity.Name}}Command, {{entity.Name}}KeyDto?>
{
	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }
	public IEntityFactory<{{entity.Name}}, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> EntityFactory { get; }

	public PartialUpdate{{entity.Name}}CommandHandlerBase(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<{{entity.Name}}KeyDto?> Handle(PartialUpdate{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		{{- for key in entity.Keys }}
		var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(request.key{{key.Name}});
		{{- end }}

		var entity = await DbContext.{{entity.PluralName}}.FindAsync({{primaryKeysFindQuery}});
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		{{- if !entity.IsOwnedEntity }}
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		{{- end }}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}
}