﻿﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;
public record Create{{entity.Name}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, {{entity.Name}}CreateDto EntityDto, System.Guid? Etag) : IRequest <{{entity.Name}}KeyDto?>;

internal partial class Create{{entity.Name}}For{{parent.Name}}CommandHandler : Create{{entity.Name}}For{{parent.Name}}CommandHandlerBase
{
	public Create{{entity.Name}}For{{parent.Name}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class Create{{entity.Name}}For{{parent.Name}}CommandHandlerBase : CommandBase<Create{{entity.Name}}For{{parent.Name}}Command, {{entity.Name}}Entity>, IRequestHandler<Create{{entity.Name}}For{{parent.Name}}Command, {{entity.Name}}KeyDto?>
{
	private readonly AppDbContext _dbContext;
	private readonly IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> _entityFactory;

	public Create{{entity.Name}}For{{parent.Name}}CommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual  async Task<{{entity.Name}}KeyDto?> Handle(Create{{entity.Name}}For{{parent.Name}}Command request, CancellationToken cancellationToken)
	{
		await OnExecutingAsync(request);

		{{- for key in parent.Keys }}
		var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{parent.Name}}Metadata.Create{{key.Name}}(request.ParentKeyDto.key{{key.Name}});
		{{- end }}

		var parentEntity = await _dbContext.{{parent.PluralName}}.FindAsync({{parentKeysFindQuery}});
		if (parentEntity == null)
		{
			return null;
		}

		var entity = _entityFactory.CreateEntity(request.EntityDto);

		{{- for key in entity.Keys ~}}
		{{- if key.Type == "Nuid" }}
		entityToCreate.Ensure{{key.Name}}();
		{{- end }}
		{{- end }}
		parentEntity.CreateRefTo{{relationship.Name}}(entity);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);

		_dbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await _dbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}
}