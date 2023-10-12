
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
using TestEntityTwoRelationshipsOneToOneEntity = TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandlerBase<CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand>
{
	public CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand>
{
	public DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToOneKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsOneToOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommandHandlerBase(
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
				entity.CreateRefToTestRelationshipTwo(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestRelationshipTwo(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestRelationshipTwo();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}