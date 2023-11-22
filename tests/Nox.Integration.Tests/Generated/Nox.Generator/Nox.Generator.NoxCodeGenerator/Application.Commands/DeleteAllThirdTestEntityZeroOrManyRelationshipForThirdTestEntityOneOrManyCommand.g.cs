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
using ThirdTestEntityZeroOrManyEntity = TestWebApp.Domain.ThirdTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllThirdTestEntityZeroOrManiesForThirdTestEntityOneOrManyCommand(ThirdTestEntityOneOrManyKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllThirdTestEntityZeroOrManiesForThirdTestEntityOneOrManyCommandHandler : DeleteAllThirdTestEntityZeroOrManiesForThirdTestEntityOneOrManyCommandHandlerBase
{
	public DeleteAllThirdTestEntityZeroOrManiesForThirdTestEntityOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllThirdTestEntityZeroOrManiesForThirdTestEntityOneOrManyCommandHandlerBase : CommandBase<DeleteAllThirdTestEntityZeroOrManiesForThirdTestEntityOneOrManyCommand, ThirdTestEntityZeroOrManyEntity>, IRequestHandler <DeleteAllThirdTestEntityZeroOrManiesForThirdTestEntityOneOrManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllThirdTestEntityZeroOrManiesForThirdTestEntityOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllThirdTestEntityZeroOrManiesForThirdTestEntityOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.ThirdTestEntityOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.ThirdTestEntityOneOrManies.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.ThirdTestEntityZeroOrManies;
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