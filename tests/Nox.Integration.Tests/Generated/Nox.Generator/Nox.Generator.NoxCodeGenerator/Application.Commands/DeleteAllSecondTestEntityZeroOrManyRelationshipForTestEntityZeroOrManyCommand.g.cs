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

public partial record DeleteAllSecondTestEntityZeroOrManiesForTestEntityZeroOrManyCommand(TestEntityZeroOrManyKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllSecondTestEntityZeroOrManiesForTestEntityZeroOrManyCommandHandler : DeleteAllSecondTestEntityZeroOrManiesForTestEntityZeroOrManyCommandHandlerBase
{
	public DeleteAllSecondTestEntityZeroOrManiesForTestEntityZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllSecondTestEntityZeroOrManiesForTestEntityZeroOrManyCommandHandlerBase : CommandBase<DeleteAllSecondTestEntityZeroOrManiesForTestEntityZeroOrManyCommand, SecondTestEntityZeroOrManyEntity>, IRequestHandler <DeleteAllSecondTestEntityZeroOrManiesForTestEntityZeroOrManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllSecondTestEntityZeroOrManiesForTestEntityZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllSecondTestEntityZeroOrManiesForTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
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
				DbContext.Entry(relatedEntity).State = EntityState.Deleted;
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