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
using TestEntityZeroOrOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllTestEntityZeroOrOneToZeroOrManiesForTestEntityZeroOrManyToZeroOrOneCommand(TestEntityZeroOrManyToZeroOrOneKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllTestEntityZeroOrOneToZeroOrManiesForTestEntityZeroOrManyToZeroOrOneCommandHandler : DeleteAllTestEntityZeroOrOneToZeroOrManiesForTestEntityZeroOrManyToZeroOrOneCommandHandlerBase
{
	public DeleteAllTestEntityZeroOrOneToZeroOrManiesForTestEntityZeroOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllTestEntityZeroOrOneToZeroOrManiesForTestEntityZeroOrManyToZeroOrOneCommandHandlerBase : CommandBase<DeleteAllTestEntityZeroOrOneToZeroOrManiesForTestEntityZeroOrManyToZeroOrOneCommand, TestEntityZeroOrOneToZeroOrManyEntity>, IRequestHandler <DeleteAllTestEntityZeroOrOneToZeroOrManiesForTestEntityZeroOrManyToZeroOrOneCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllTestEntityZeroOrOneToZeroOrManiesForTestEntityZeroOrManyToZeroOrOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllTestEntityZeroOrOneToZeroOrManiesForTestEntityZeroOrManyToZeroOrOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.TestEntityZeroOrManyToZeroOrOnes.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.TestEntityZeroOrOneToZeroOrManies;
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