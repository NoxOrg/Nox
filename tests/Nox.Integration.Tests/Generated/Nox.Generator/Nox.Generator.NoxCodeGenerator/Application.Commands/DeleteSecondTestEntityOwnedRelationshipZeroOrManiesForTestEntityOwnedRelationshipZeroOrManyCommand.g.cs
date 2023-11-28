﻿
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
using SecondTestEntityOwnedRelationshipZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrMany;

namespace TestWebApp.Application.Commands;
public partial record DeleteSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(TestEntityOwnedRelationshipZeroOrManyKeyDto ParentKeyDto, SecondTestEntityOwnedRelationshipZeroOrManyKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler : DeleteSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase
{
	public DeleteSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase : CommandBase<DeleteSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, SecondTestEntityOwnedRelationshipZeroOrManyEntity>, IRequestHandler <DeleteSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.TestEntityOwnedRelationshipZeroOrManies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		await DbContext.Entry(parentEntity).Collection(p => p.SecondTestEntityOwnedRelationshipZeroOrManies).LoadAsync(cancellationToken);
		var ownedId = TestWebApp.Domain.SecondTestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.SecondTestEntityOwnedRelationshipZeroOrManies.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return false;
		}
		parentEntity.SecondTestEntityOwnedRelationshipZeroOrManies.Remove(entity);
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