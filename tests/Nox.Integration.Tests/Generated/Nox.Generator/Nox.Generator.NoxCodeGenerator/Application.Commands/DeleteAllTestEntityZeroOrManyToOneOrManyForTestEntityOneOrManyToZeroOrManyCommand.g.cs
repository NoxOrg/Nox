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
using TestEntityZeroOrManyToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllTestEntityZeroOrManyToOneOrManiesForTestEntityOneOrManyToZeroOrManyCommand(TestEntityOneOrManyToZeroOrManyKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllTestEntityZeroOrManyToOneOrManiesForTestEntityOneOrManyToZeroOrManyCommandHandler : DeleteAllTestEntityZeroOrManyToOneOrManiesForTestEntityOneOrManyToZeroOrManyCommandHandlerBase
{
	public DeleteAllTestEntityZeroOrManyToOneOrManiesForTestEntityOneOrManyToZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllTestEntityZeroOrManyToOneOrManiesForTestEntityOneOrManyToZeroOrManyCommandHandlerBase : CommandBase<DeleteAllTestEntityZeroOrManyToOneOrManiesForTestEntityOneOrManyToZeroOrManyCommand, TestEntityZeroOrManyToOneOrManyEntity>, IRequestHandler <DeleteAllTestEntityZeroOrManyToOneOrManiesForTestEntityOneOrManyToZeroOrManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllTestEntityZeroOrManyToOneOrManiesForTestEntityOneOrManyToZeroOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllTestEntityZeroOrManyToOneOrManiesForTestEntityOneOrManyToZeroOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.TestEntityOneOrManyToZeroOrManies.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.TestEntityZeroOrManyToOneOrManies;
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