
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
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto, ThirdTestEntityZeroOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto, ThirdTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand>
{
	public CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto, ThirdTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand>
{
	public DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand>
{
	public DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.ThirdTestEntityOneOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.ThirdTestEntityOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.ThirdTestEntityZeroOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.ThirdTestEntityZeroOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.ThirdTestEntityZeroOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToThirdTestEntityZeroOrManies(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToThirdTestEntityZeroOrManies(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.ThirdTestEntityZeroOrManies).LoadAsync();
				entity.DeleteAllRefToThirdTestEntityZeroOrManies();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}