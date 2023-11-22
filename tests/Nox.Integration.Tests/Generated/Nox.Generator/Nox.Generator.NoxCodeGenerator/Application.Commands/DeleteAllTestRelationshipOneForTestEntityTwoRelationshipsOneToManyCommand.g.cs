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
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllTestRelationshipOneForTestEntityTwoRelationshipsOneToManyCommand(TestEntityTwoRelationshipsOneToManyKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllTestRelationshipOneForTestEntityTwoRelationshipsOneToManyCommandHandler : DeleteAllTestRelationshipOneForTestEntityTwoRelationshipsOneToManyCommandHandlerBase
{
	public DeleteAllTestRelationshipOneForTestEntityTwoRelationshipsOneToManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllTestRelationshipOneForTestEntityTwoRelationshipsOneToManyCommandHandlerBase : CommandBase<DeleteAllTestRelationshipOneForTestEntityTwoRelationshipsOneToManyCommand, SecondTestEntityTwoRelationshipsOneToManyEntity>, IRequestHandler <DeleteAllTestRelationshipOneForTestEntityTwoRelationshipsOneToManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllTestRelationshipOneForTestEntityTwoRelationshipsOneToManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllTestRelationshipOneForTestEntityTwoRelationshipsOneToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.TestRelationshipOne;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{DbContext.SecondTestEntityTwoRelationshipsOneToManies.Remove(relatedEntity);
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