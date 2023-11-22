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
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllTestRelationshipTwoForTestEntityTwoRelationshipsManyToManyCommand(TestEntityTwoRelationshipsManyToManyKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllTestRelationshipTwoForTestEntityTwoRelationshipsManyToManyCommandHandler : DeleteAllTestRelationshipTwoForTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public DeleteAllTestRelationshipTwoForTestEntityTwoRelationshipsManyToManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllTestRelationshipTwoForTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<DeleteAllTestRelationshipTwoForTestEntityTwoRelationshipsManyToManyCommand, SecondTestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler <DeleteAllTestRelationshipTwoForTestEntityTwoRelationshipsManyToManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllTestRelationshipTwoForTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllTestRelationshipTwoForTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.TestRelationshipTwo;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{DbContext.SecondTestEntityTwoRelationshipsManyToManies.Remove(relatedEntity);
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