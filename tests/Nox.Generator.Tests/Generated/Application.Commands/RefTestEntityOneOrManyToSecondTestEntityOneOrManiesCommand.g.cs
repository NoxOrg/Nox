
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

public abstract record RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand>
{
	public CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand>
{
	public DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(TestEntityOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand>
{
	public DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommandHandlerBase(
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
				entity.CreateRefToSecondTestEntityOneOrManies(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToSecondTestEntityOneOrManies(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.SecondTestEntityOneOrManies).LoadAsync();
				entity.DeleteAllRefToSecondTestEntityOneOrManies();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}