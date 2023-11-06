
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
using TestEntityExactlyOneToOneOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(TestEntityExactlyOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToExactlyOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(TestEntityExactlyOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase<CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand>
{
	public CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(TestEntityExactlyOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase<DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand>
{
	public DeleteRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(TestEntityExactlyOneToOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase<DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand>
{
	public DeleteAllRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityExactlyOneToOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityExactlyOneToOneOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityExactlyOneToOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityOneOrManyToExactlyOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityOneOrManyToExactlyOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityOneOrManyToExactlyOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityOneOrManyToExactlyOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityOneOrManyToExactlyOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestEntityOneOrManyToExactlyOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}