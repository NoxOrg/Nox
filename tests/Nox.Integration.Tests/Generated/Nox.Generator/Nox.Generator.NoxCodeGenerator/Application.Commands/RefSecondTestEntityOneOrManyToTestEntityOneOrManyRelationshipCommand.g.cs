
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
using SecondTestEntityOneOrManyEntity = TestWebApp.Domain.SecondTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommandHandler
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommandHandlerBase<CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand>
{
	public CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommandHandler
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommandHandlerBase<DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand>
{
	public DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand(SecondTestEntityOneOrManyKeyDto EntityKeyDto)
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommandHandler
	: RefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommandHandlerBase<DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand>
{
	public DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.SecondTestEntityOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityOneOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityOneOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityOneOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityOneOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityOneOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityOneOrManyRelationship).LoadAsync();
				entity.DeleteAllRefToTestEntityOneOrManyRelationship();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}