﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Commands;
public record DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(TestEntityOwnedRelationshipExactlyOneKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler : DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase : CommandBase<DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecondTestEntityOwnedRelationshipExactlyOneEntity>, IRequestHandler <DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, bool>
{
	public TestWebAppDbContext DbContext { get; }

	public DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.TestEntityOwnedRelationshipExactlyOnes.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var entity = parentEntity.SecondTestEntityOwnedRelationshipExactlyOne;
		if (entity == null)
		{
			return false;
		}

		parentEntity.SecondTestEntityOwnedRelationshipExactlyOne = null!;

		OnCompleted(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}