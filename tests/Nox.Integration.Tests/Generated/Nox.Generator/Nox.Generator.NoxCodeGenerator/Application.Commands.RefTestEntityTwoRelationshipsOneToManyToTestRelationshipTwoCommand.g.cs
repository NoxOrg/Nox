
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

public abstract record RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand>
{
	public CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsOneToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand>
{
	public DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsOneToManyKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsOneToMany>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityTwoRelationshipsOneToManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		SecondTestEntityTwoRelationshipsOneToMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.SecondTestEntityTwoRelationshipsOneToManies.FindAsync(relatedKeyId);
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
				await DbContext.Entry(entity).Collection(x => x.TestRelationshipTwo).LoadAsync();
				entity.DeleteAllRefToTestRelationshipTwo();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}