
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
using ThirdTestEntityZeroOrManyEntity = TestWebApp.Domain.ThirdTestEntityZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto, ThirdTestEntityOneOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto, ThirdTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand>
{
	public CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto, ThirdTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand>
{
	public DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand>
{
	public DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.ThirdTestEntityZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.ThirdTestEntityZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.ThirdTestEntityOneOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.ThirdTestEntityOneOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.ThirdTestEntityOneOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToThirdTestEntityOneOrManies(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToThirdTestEntityOneOrManies(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.ThirdTestEntityOneOrManies).LoadAsync();
				entity.DeleteAllRefToThirdTestEntityOneOrManies();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}