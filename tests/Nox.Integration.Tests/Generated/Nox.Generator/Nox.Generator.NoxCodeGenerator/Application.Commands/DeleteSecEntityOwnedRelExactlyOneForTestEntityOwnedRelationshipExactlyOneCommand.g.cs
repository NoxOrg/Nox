﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using SecEntityOwnedRelExactlyOneEntity = TestWebApp.Domain.SecEntityOwnedRelExactlyOne;

namespace TestWebApp.Application.Commands;
public partial record DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(TestEntityOwnedRelationshipExactlyOneKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler : DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase
{
	public DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase : CommandBase<DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, SecEntityOwnedRelExactlyOneEntity>, IRequestHandler <DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.TestEntityOwnedRelationshipExactlyOnes.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipExactlyOne",  $"{keyId.ToString()}");
		}
		await DbContext.Entry(parentEntity).Reference(e => e.SecEntityOwnedRelExactlyOne).LoadAsync(cancellationToken);
		var entity = parentEntity.SecEntityOwnedRelExactlyOne;
		if (entity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipExactlyOne.SecEntityOwnedRelExactlyOne",  String.Empty);
		}

		parentEntity.DeleteRefToSecEntityOwnedRelExactlyOne(entity);

		await OnCompletedAsync(request, entity);

		
		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}

		return true;
	}
}