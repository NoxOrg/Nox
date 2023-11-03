
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
using TestEntityZeroOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand>
{
	public CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand>
{
	public DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyToExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityZeroOrManyToExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityExactlyOneToZeroOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityExactlyOneToZeroOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityExactlyOneToZeroOrManies(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityExactlyOneToZeroOrManies(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityExactlyOneToZeroOrManies).LoadAsync();
				entity.DeleteAllRefToTestEntityExactlyOneToZeroOrManies();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}