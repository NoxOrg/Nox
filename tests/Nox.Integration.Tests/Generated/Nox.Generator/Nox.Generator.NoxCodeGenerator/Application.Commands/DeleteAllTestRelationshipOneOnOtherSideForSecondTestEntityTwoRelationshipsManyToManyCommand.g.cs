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
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public partial record DeleteAllTestRelationshipOneOnOtherSideForSecondTestEntityTwoRelationshipsManyToManyCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllTestRelationshipOneOnOtherSideForSecondTestEntityTwoRelationshipsManyToManyCommandHandler : DeleteAllTestRelationshipOneOnOtherSideForSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase
{
	public DeleteAllTestRelationshipOneOnOtherSideForSecondTestEntityTwoRelationshipsManyToManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllTestRelationshipOneOnOtherSideForSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase : CommandBase<DeleteAllTestRelationshipOneOnOtherSideForSecondTestEntityTwoRelationshipsManyToManyCommand, TestEntityTwoRelationshipsManyToManyEntity>, IRequestHandler <DeleteAllTestRelationshipOneOnOtherSideForSecondTestEntityTwoRelationshipsManyToManyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllTestRelationshipOneOnOtherSideForSecondTestEntityTwoRelationshipsManyToManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllTestRelationshipOneOnOtherSideForSecondTestEntityTwoRelationshipsManyToManyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.SecondTestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.TestRelationshipOneOnOtherSide;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.TestEntityTwoRelationshipsManyToManies.Remove(relatedEntity);
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