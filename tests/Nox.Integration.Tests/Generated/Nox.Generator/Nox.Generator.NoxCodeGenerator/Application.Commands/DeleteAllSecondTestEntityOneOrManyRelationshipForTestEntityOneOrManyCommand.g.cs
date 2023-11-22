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
using SecondTestEntityOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllSecondTestEntityOneOrManyRelationshipForTestEntityOneOrManyCommand(TestEntityOneOrManyKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllSecondTestEntityOneOrManyRelationshipForTestEntityOneOrManyCommandHandler : DeleteAllSecondTestEntityOneOrManyRelationshipForTestEntityOneOrManyCommandHandlerBase
{
	public DeleteAllSecondTestEntityOneOrManyRelationshipForTestEntityOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllSecondTestEntityOneOrManyRelationshipForTestEntityOneOrManyCommandHandlerBase : CommandBase<DeleteAllSecondTestEntityOneOrManyRelationshipForTestEntityOneOrManyCommand, SecondTestEntityOneOrManyEntity>, IRequestHandler <DeleteAllSecondTestEntityOneOrManyRelationshipForTestEntityOneOrManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllSecondTestEntityOneOrManyRelationshipForTestEntityOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllSecondTestEntityOneOrManyRelationshipForTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.TestEntityOneOrManies.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.SecondTestEntityOneOrManies;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.SecondTestEntityOneOrManies.Remove(relatedEntity);
				await OnCompletedAsync(request, relatedEntity);
			}
			
			await trx.CommitAsync();
			
			var result = await DbContext.SaveChangesAsync(cancellationToken);
			if (result < 1)
			{
				return false;
			}

			return true;
		}
		catch
		{
			await trx.RollbackAsync();
			return false;
		}
	}
}