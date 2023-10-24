﻿
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using TestEntityOneOrManyToZeroOrManyEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToOneOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommandHandler
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommandHandlerBase<CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommand>
{
	public CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommandHandler
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommandHandlerBase<DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommand>
{
	public DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommandHandler
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommand>
{
	public DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyToZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		RelationshipAction action)
		: base(noxSolution)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityOneOrManyToZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityZeroOrManyToOneOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityZeroOrManyToOneOrMany(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityZeroOrManyToOneOrMany(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrManyToOneOrMany).LoadAsync();
				entity.DeleteAllRefToTestEntityZeroOrManyToOneOrMany();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}