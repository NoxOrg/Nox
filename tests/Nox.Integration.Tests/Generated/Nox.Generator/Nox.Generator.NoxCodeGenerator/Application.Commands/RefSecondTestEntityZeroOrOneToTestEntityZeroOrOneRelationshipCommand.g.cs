﻿
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommandHandler
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommandHandlerBase<CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommand>
{
	public CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommandHandler
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommandHandlerBase<DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommand>
{
	public DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto)
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommandHandler
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommandHandlerBase<DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommand>
{
	public DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneRelationshipCommandHandlerBase(
        AppDbContext dbContext,
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
		var keyId = TestWebApp.Domain.SecondTestEntityZeroOrOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.SecondTestEntityZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityZeroOrOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityZeroOrOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityZeroOrOneRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityZeroOrOneRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestEntityZeroOrOneRelationship();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}