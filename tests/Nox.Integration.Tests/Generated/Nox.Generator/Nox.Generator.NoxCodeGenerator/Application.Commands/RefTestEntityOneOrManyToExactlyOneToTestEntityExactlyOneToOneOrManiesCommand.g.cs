
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
using TestEntityOneOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityOneOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToOneOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandlerBase<CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand>
{
	public CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandlerBase<DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand>
{
	public DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand>
{
	public DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyToExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToExactlyOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityOneOrManyToExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityExactlyOneToOneOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityExactlyOneToOneOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityExactlyOneToOneOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityExactlyOneToOneOrManies(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityExactlyOneToOneOrManies(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityExactlyOneToOneOrManies).LoadAsync();
				entity.DeleteAllRefToTestEntityExactlyOneToOneOrManies();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}