
﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecondTestEntityOwnedRelationshipExactlyOneEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipExactlyOne;

namespace TestWebApp.Application.Commands;
public partial record DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(TestEntityOwnedRelationshipExactlyOneKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler : DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase : CommandBase<DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecondTestEntityOwnedRelationshipExactlyOneEntity>, IRequestHandler <DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.TestEntityOwnedRelationshipExactlyOnes.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		await DbContext.Entry(parentEntity).Reference(e => e.SecondTestEntityOwnedRelationshipExactlyOne).LoadAsync(cancellationToken);
		var entity = parentEntity.SecondTestEntityOwnedRelationshipExactlyOne;
		if (entity == null)
		{
			return false;
		}

		parentEntity.DeleteRefToSecondTestEntityOwnedRelationshipExactlyOne(entity);

		await OnCompletedAsync(request, entity);

		
		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}