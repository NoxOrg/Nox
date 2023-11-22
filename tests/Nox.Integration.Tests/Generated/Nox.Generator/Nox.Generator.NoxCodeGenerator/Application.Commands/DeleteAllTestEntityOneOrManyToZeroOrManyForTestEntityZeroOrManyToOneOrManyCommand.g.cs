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
using TestEntityOneOrManyToZeroOrManyEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllTestEntityOneOrManyToZeroOrManyForTestEntityZeroOrManyToOneOrManyCommand(TestEntityZeroOrManyToOneOrManyKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllTestEntityOneOrManyToZeroOrManyForTestEntityZeroOrManyToOneOrManyCommandHandler : DeleteAllTestEntityOneOrManyToZeroOrManyForTestEntityZeroOrManyToOneOrManyCommandHandlerBase
{
	public DeleteAllTestEntityOneOrManyToZeroOrManyForTestEntityZeroOrManyToOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllTestEntityOneOrManyToZeroOrManyForTestEntityZeroOrManyToOneOrManyCommandHandlerBase : CommandBase<DeleteAllTestEntityOneOrManyToZeroOrManyForTestEntityZeroOrManyToOneOrManyCommand, TestEntityOneOrManyToZeroOrManyEntity>, IRequestHandler <DeleteAllTestEntityOneOrManyToZeroOrManyForTestEntityZeroOrManyToOneOrManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllTestEntityOneOrManyToZeroOrManyForTestEntityZeroOrManyToOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllTestEntityOneOrManyToZeroOrManyForTestEntityZeroOrManyToOneOrManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.TestEntityZeroOrManyToOneOrManies.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.TestEntityOneOrManyToZeroOrManies;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.TestEntityOneOrManyToZeroOrManies.Remove(relatedEntity);
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