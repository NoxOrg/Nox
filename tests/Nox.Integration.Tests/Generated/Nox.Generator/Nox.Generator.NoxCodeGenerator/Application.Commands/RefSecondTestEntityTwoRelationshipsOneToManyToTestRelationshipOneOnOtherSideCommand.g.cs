
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
using SecondTestEntityTwoRelationshipsOneToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand>
{
	public CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand>
{
	public DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto, null);

internal partial class DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand>
{
	public DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityTwoRelationshipsOneToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestRelationshipOneOnOtherSide(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestRelationshipOneOnOtherSide(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestRelationshipOneOnOtherSide();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}