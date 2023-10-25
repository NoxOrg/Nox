
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
using TestEntityTwoRelationshipsManyToManyEntity = TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsManyToManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand>
{
	public CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand>
{
	public DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsManyToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityTwoRelationshipsManyToManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.SecondTestEntityTwoRelationshipsManyToManies.FindAsync(relatedKeyId);
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

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}