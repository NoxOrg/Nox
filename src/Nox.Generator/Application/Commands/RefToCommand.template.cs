﻿{{-relatedEntity = relationship.Related.Entity }}
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public abstract record Ref{{entity.Name}}To{{relationship.Name}}Command({{entity.Name}}KeyDto EntityKeyDto, {{relatedEntity.Name}}KeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRef{{entity.Name}}To{{relationship.Name}}Command({{entity.Name}}KeyDto EntityKeyDto, {{relatedEntity.Name}}KeyDto RelatedEntityKeyDto)
	: Ref{{entity.Name}}To{{relationship.Name}}Command(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRef{{entity.Name}}To{{relationship.Name}}CommandHandler
	: Ref{{entity.Name}}To{{relationship.Name}}CommandHandlerBase<CreateRef{{entity.Name}}To{{relationship.Name}}Command>
{
	public CreateRef{{entity.Name}}To{{relationship.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRef{{entity.Name}}To{{relationship.Name}}Command({{entity.Name}}KeyDto EntityKeyDto, {{relatedEntity.Name}}KeyDto RelatedEntityKeyDto)
	: Ref{{entity.Name}}To{{relationship.Name}}Command(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRef{{entity.Name}}To{{relationship.Name}}CommandHandler
	: Ref{{entity.Name}}To{{relationship.Name}}CommandHandlerBase<DeleteRef{{entity.Name}}To{{relationship.Name}}Command>
{
	public DeleteRef{{entity.Name}}To{{relationship.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRef{{entity.Name}}To{{relationship.Name}}Command({{entity.Name}}KeyDto EntityKeyDto)
	: Ref{{entity.Name}}To{{relationship.Name}}Command(EntityKeyDto, null);

internal partial class DeleteAllRef{{entity.Name}}To{{relationship.Name}}CommandHandler
	: Ref{{entity.Name}}To{{relationship.Name}}CommandHandlerBase<DeleteAllRef{{entity.Name}}To{{relationship.Name}}Command>
{
	public DeleteAllRef{{entity.Name}}To{{relationship.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class Ref{{entity.Name}}To{{relationship.Name}}CommandHandlerBase<TRequest> : CommandBase<TRequest, {{entity.Name}}Entity>,
	IRequestHandler <TRequest, bool> where TRequest : Ref{{entity.Name}}To{{relationship.Name}}Command
{
	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public Ref{{entity.Name}}To{{relationship.Name}}CommandHandlerBase(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		RelationshipAction action)
		: base(noxSolution)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		{{- for key in entity.Keys }}
		var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(request.EntityKeyDto.key{{key.Name}});
		{{- end }}
		var entity = await DbContext.{{entity.PluralName}}.FindAsync({{entityKeysFindQuery}});
		if (entity == null)
		{
			return false;
		}

		{{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			{{- for key in relatedEntity.Keys }}
			var relatedKey{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}Metadata.Create{{key.Name}}(request.RelatedEntityKeyDto.key{{key.Name}});
			{{- end }}
			relatedEntity = await DbContext.{{relatedEntity.PluralName}}.FindAsync({{relatedEntityKeysFindQuery}});
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefTo{{relationship.Name}}(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefTo{{relationship.Name}}(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
			{{- if relationship.WithMultiEntity }}
				await DbContext.Entry(entity).Collection(x => x.{{relationship.Name}}).LoadAsync();
			{{- end }}
				entity.DeleteAllRefTo{{relationship.Name}}();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}