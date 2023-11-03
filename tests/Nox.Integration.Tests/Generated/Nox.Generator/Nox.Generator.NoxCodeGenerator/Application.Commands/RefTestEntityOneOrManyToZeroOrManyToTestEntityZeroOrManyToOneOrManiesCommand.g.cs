
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
using TestEntityOneOrManyToZeroOrManyEntity = TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToOneOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandlerBase<CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand>
{
	public CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandlerBase<DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand>
{
	public DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(TestEntityOneOrManyToZeroOrManyKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand>
{
	public DeleteAllRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyToZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityOneOrManyToZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrManyToOneOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityZeroOrManyToOneOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityZeroOrManyToOneOrManies(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityZeroOrManyToOneOrManies(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrManyToOneOrManies).LoadAsync();
				entity.DeleteAllRefToTestEntityZeroOrManyToOneOrManies();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}