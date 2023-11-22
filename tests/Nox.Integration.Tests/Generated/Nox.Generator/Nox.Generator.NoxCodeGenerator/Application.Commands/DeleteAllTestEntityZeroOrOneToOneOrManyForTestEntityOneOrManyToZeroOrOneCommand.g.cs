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
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllTestEntityZeroOrOneToOneOrManiesForTestEntityOneOrManyToZeroOrOneCommand(TestEntityOneOrManyToZeroOrOneKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllTestEntityZeroOrOneToOneOrManiesForTestEntityOneOrManyToZeroOrOneCommandHandler : DeleteAllTestEntityZeroOrOneToOneOrManiesForTestEntityOneOrManyToZeroOrOneCommandHandlerBase
{
	public DeleteAllTestEntityZeroOrOneToOneOrManiesForTestEntityOneOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllTestEntityZeroOrOneToOneOrManiesForTestEntityOneOrManyToZeroOrOneCommandHandlerBase : CommandBase<DeleteAllTestEntityZeroOrOneToOneOrManiesForTestEntityOneOrManyToZeroOrOneCommand, TestEntityZeroOrOneToOneOrManyEntity>, IRequestHandler <DeleteAllTestEntityZeroOrOneToOneOrManiesForTestEntityOneOrManyToZeroOrOneCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllTestEntityZeroOrOneToOneOrManiesForTestEntityOneOrManyToZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllTestEntityZeroOrOneToOneOrManiesForTestEntityOneOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.TestEntityOneOrManyToZeroOrOnes.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.TestEntityZeroOrOneToOneOrManies;
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