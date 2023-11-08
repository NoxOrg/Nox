
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

public abstract record RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsManyToManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandlerBase<CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand>
{
	public CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto, SecondTestEntityTwoRelationshipsManyToManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandlerBase<DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand>
{
	public DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(TestEntityTwoRelationshipsManyToManyKeyDto EntityKeyDto)
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler
	: RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandlerBase<DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand>
{
	public DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityTwoRelationshipsManyToManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommandHandlerBase(
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
				entity.CreateRefToTestRelationshipOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestRelationshipOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestRelationshipOne).LoadAsync();
				entity.DeleteAllRefToTestRelationshipOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}