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
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllThirdTestEntityOneOrManiesForThirdTestEntityZeroOrManyCommand(ThirdTestEntityZeroOrManyKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllThirdTestEntityOneOrManiesForThirdTestEntityZeroOrManyCommandHandler : DeleteAllThirdTestEntityOneOrManiesForThirdTestEntityZeroOrManyCommandHandlerBase
{
	public DeleteAllThirdTestEntityOneOrManiesForThirdTestEntityZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllThirdTestEntityOneOrManiesForThirdTestEntityZeroOrManyCommandHandlerBase : CommandBase<DeleteAllThirdTestEntityOneOrManiesForThirdTestEntityZeroOrManyCommand, ThirdTestEntityOneOrManyEntity>, IRequestHandler <DeleteAllThirdTestEntityOneOrManiesForThirdTestEntityZeroOrManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllThirdTestEntityOneOrManiesForThirdTestEntityZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllThirdTestEntityOneOrManiesForThirdTestEntityZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.ThirdTestEntityZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.ThirdTestEntityZeroOrManies.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.ThirdTestEntityOneOrManies;
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