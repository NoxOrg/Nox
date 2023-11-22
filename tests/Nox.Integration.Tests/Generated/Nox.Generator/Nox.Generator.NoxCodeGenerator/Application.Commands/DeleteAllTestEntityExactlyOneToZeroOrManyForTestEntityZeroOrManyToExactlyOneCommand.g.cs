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
using TestEntityExactlyOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllTestEntityExactlyOneToZeroOrManyForTestEntityZeroOrManyToExactlyOneCommand(TestEntityZeroOrManyToExactlyOneKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllTestEntityExactlyOneToZeroOrManyForTestEntityZeroOrManyToExactlyOneCommandHandler : DeleteAllTestEntityExactlyOneToZeroOrManyForTestEntityZeroOrManyToExactlyOneCommandHandlerBase
{
	public DeleteAllTestEntityExactlyOneToZeroOrManyForTestEntityZeroOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllTestEntityExactlyOneToZeroOrManyForTestEntityZeroOrManyToExactlyOneCommandHandlerBase : CommandBase<DeleteAllTestEntityExactlyOneToZeroOrManyForTestEntityZeroOrManyToExactlyOneCommand, TestEntityExactlyOneToZeroOrManyEntity>, IRequestHandler <DeleteAllTestEntityExactlyOneToZeroOrManyForTestEntityZeroOrManyToExactlyOneCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllTestEntityExactlyOneToZeroOrManyForTestEntityZeroOrManyToExactlyOneCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllTestEntityExactlyOneToZeroOrManyForTestEntityZeroOrManyToExactlyOneCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOneMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.TestEntityZeroOrManyToExactlyOnes.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.TestEntityExactlyOneToZeroOrManies;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.TestEntityExactlyOneToZeroOrManies.Remove(relatedEntity);
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