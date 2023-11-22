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
using TestEntityOneOrManyEntity = TestWebApp.Domain.TestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllTestEntityOneOrManyRelationshipForSecondTestEntityOneOrManyCommand(SecondTestEntityOneOrManyKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllTestEntityOneOrManyRelationshipForSecondTestEntityOneOrManyCommandHandler : DeleteAllTestEntityOneOrManyRelationshipForSecondTestEntityOneOrManyCommandHandlerBase
{
	public DeleteAllTestEntityOneOrManyRelationshipForSecondTestEntityOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllTestEntityOneOrManyRelationshipForSecondTestEntityOneOrManyCommandHandlerBase : CommandBase<DeleteAllTestEntityOneOrManyRelationshipForSecondTestEntityOneOrManyCommand, TestEntityOneOrManyEntity>, IRequestHandler <DeleteAllTestEntityOneOrManyRelationshipForSecondTestEntityOneOrManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllTestEntityOneOrManyRelationshipForSecondTestEntityOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllTestEntityOneOrManyRelationshipForSecondTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.SecondTestEntityOneOrManies.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.TestEntityOneOrManies;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.TestEntityOneOrManies.Remove(relatedEntity);
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