
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
using SecondTestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsManyToManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand>
{
	public CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, TestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand>
{
	public DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(SecondTestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto)
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(EntityKeyDto, null);

internal partial class DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler
	: RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand>
{
	public DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityTwoRelationshipsManyToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommandHandlerBase(
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
		await OnExecutingAsync(request);
		var keyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.SecondTestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(relatedKeyId);
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
				await DbContext.Entry(entity).Collection(x => x.TestRelationshipOneOnOtherSide).LoadAsync();
				entity.DeleteAllRefToTestRelationshipOneOnOtherSide();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}