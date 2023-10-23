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
using ThirdTestEntityExactlyOneEntity = TestWebApp.Domain.ThirdTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand(ThirdTestEntityExactlyOneKeyDto EntityKeyDto, ThirdTestEntityZeroOrOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand(ThirdTestEntityExactlyOneKeyDto EntityKeyDto, ThirdTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommandHandler
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommandHandlerBase<CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand>
{
	public CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand(ThirdTestEntityExactlyOneKeyDto EntityKeyDto, ThirdTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommandHandler
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommandHandlerBase<DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand>
{
	public DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand(ThirdTestEntityExactlyOneKeyDto EntityKeyDto)
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommandHandler
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommandHandlerBase<DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand>
{
	public DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommandHandlerBase(
		TestWebAppDbContext dbContext,
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
		var keyId = TestWebApp.Domain.ThirdTestEntityExactlyOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.ThirdTestEntityExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.ThirdTestEntityZeroOrOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.ThirdTestEntityZeroOrOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.ThirdTestEntityZeroOrOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToThirdTestEntityZeroOrOneRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToThirdTestEntityZeroOrOneRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToThirdTestEntityZeroOrOneRelationship();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}