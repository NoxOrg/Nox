
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
using SecondTestEntityZeroOrManyEntity = TestWebApp.Domain.SecondTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand>
{
	public CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand>
{
	public DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand>
{
	public DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.SecondTestEntityZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.SecondTestEntityZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityZeroOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityZeroOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityZeroOrManies(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityZeroOrManies(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrManies).LoadAsync();
				entity.DeleteAllRefToTestEntityZeroOrManies();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}