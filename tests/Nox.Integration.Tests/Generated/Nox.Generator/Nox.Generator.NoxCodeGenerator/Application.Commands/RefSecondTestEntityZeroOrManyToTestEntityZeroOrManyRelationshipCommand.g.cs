
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
using SecondTestEntityZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandlerBase<CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand>
{
	public CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandlerBase<DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand>
{
	public DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandlerBase<DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand>
{
	public DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.SecondTestEntityZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.SecondTestEntityZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityZeroOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityZeroOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityZeroOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityZeroOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrManyRelationship).LoadAsync();
				entity.DeleteAllRefToTestEntityZeroOrManyRelationship();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}