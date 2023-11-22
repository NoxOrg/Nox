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
using SecondTestEntityZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllSecondTestEntityZeroOrManyRelationshipForTestEntityZeroOrManyCommand(TestEntityZeroOrManyKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllSecondTestEntityZeroOrManyRelationshipForTestEntityZeroOrManyCommandHandler : DeleteAllSecondTestEntityZeroOrManyRelationshipForTestEntityZeroOrManyCommandHandlerBase
{
	public DeleteAllSecondTestEntityZeroOrManyRelationshipForTestEntityZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllSecondTestEntityZeroOrManyRelationshipForTestEntityZeroOrManyCommandHandlerBase : CommandBase<DeleteAllSecondTestEntityZeroOrManyRelationshipForTestEntityZeroOrManyCommand, SecondTestEntityZeroOrManyEntity>, IRequestHandler <DeleteAllSecondTestEntityZeroOrManyRelationshipForTestEntityZeroOrManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllSecondTestEntityZeroOrManyRelationshipForTestEntityZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllSecondTestEntityZeroOrManyRelationshipForTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.TestEntityZeroOrManies.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.SecondTestEntityZeroOrManies;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.SecondTestEntityZeroOrManies.Remove(relatedEntity);
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