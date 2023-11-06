
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

public abstract record RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto, ThirdTestEntityOneOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto, ThirdTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommandHandlerBase<CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommand>
{
	public CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto, ThirdTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommandHandlerBase<DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommand>
{
	public DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommand(ThirdTestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommandHandler
	: RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommandHandlerBase<DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommand>
{
	public DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManyRelationshipCommandHandlerBase(
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
				entity.CreateRefToThirdTestEntityOneOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToThirdTestEntityOneOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.ThirdTestEntityOneOrManyRelationship).LoadAsync();
				entity.DeleteAllRefToThirdTestEntityOneOrManyRelationship();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}