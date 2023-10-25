
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
using TestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandlerBase<CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand>
{
	public CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand>
{
	public DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsOneToOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityTwoRelationshipsOneToOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.SecondTestEntityTwoRelationshipsOneToOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestRelationshipOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestRelationshipOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestRelationshipOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}