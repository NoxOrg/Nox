
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommandHandler
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommandHandlerBase<CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommand>
{
	public CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommandHandler
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommandHandlerBase<DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommand>
{
	public DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto)
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommandHandler
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommandHandlerBase<DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommand>
{
	public DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityExactlyOne>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefSecondTestEntityExactlyOneToTestEntityExactlyOneRelationshipCommandHandlerBase(
		TestWebAppDbContext dbContext,
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
		var keyId = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.SecondTestEntityExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestEntityExactlyOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityExactlyOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityExactlyOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityExactlyOneRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityExactlyOneRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestEntityExactlyOneRelationship();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}