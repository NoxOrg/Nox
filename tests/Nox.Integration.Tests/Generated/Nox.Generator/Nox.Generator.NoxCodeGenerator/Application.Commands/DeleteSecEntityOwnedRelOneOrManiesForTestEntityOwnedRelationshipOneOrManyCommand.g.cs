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
using SecEntityOwnedRelOneOrManyEntity = TestWebApp.Domain.SecEntityOwnedRelOneOrMany;

namespace TestWebApp.Application.Commands;
public partial record DeleteSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(TestEntityOwnedRelationshipOneOrManyKeyDto ParentKeyDto, SecEntityOwnedRelOneOrManyKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandler : DeleteSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase
{
	public DeleteSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase : CommandBase<DeleteSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand, SecEntityOwnedRelOneOrManyEntity>, IRequestHandler <DeleteSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.TestEntityOwnedRelationshipOneOrManies.FindAsync(keyId);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("TestEntityOwnedRelationshipOneOrMany",  $"{keyId.ToString()}");
		}
		await DbContext.Entry(parentEntity).Collection(p => p.SecEntityOwnedRelOneOrManies).LoadAsync(cancellationToken);
		var ownedId = TestWebApp.Domain.SecEntityOwnedRelOneOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.SecEntityOwnedRelOneOrManies.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("SecEntityOwnedRelOneOrMany.SecEntityOwnedRelOneOrManies",  $"{ownedId.ToString()}");
		}
		parentEntity.SecEntityOwnedRelOneOrManies.Remove(entity);
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);

		return true;
	}
}