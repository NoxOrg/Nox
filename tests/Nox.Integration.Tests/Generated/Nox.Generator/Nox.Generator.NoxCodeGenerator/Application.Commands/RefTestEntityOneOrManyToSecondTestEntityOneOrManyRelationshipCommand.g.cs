
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
using TestEntityOneOrManyEntity = TestWebApp.Domain.TestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandlerBase<CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand>
{
	public CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandlerBase<DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand>
{
	public DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(TestEntityOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand>
{
	public DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityOneOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.SecondTestEntityOneOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.SecondTestEntityOneOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.SecondTestEntityOneOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToSecondTestEntityOneOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToSecondTestEntityOneOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.SecondTestEntityOneOrManyRelationship).LoadAsync();
				entity.DeleteAllRefToSecondTestEntityOneOrManyRelationship();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}