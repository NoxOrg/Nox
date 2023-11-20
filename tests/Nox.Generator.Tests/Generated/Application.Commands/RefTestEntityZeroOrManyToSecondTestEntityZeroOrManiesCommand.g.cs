
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
using TestEntityZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto, SecondTestEntityZeroOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto, SecondTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand>
{
	public CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto, SecondTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand>
{
	public DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(TestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.SecondTestEntityZeroOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.SecondTestEntityZeroOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.SecondTestEntityZeroOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToSecondTestEntityZeroOrManies(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToSecondTestEntityZeroOrManies(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.SecondTestEntityZeroOrManies).LoadAsync();
				entity.DeleteAllRefToSecondTestEntityZeroOrManies();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}