
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
using SecondTestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandlerBase<CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand>
{
	public CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandlerBase<DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand>
{
	public DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(EntityKeyDto, null);

internal partial class DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandlerBase<DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand>
{
	public DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityTwoRelationshipsOneToOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.SecondTestEntityTwoRelationshipsOneToOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityTwoRelationshipsOneToOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestRelationshipTwoOnOtherSide(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestRelationshipTwoOnOtherSide(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestRelationshipTwoOnOtherSide();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}