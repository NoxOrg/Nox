
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using TestWebApp.Infrastructure.Persistence;
using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using ThirdTestEntityOneOrManyEntity = TestWebApp.Domain.ThirdTestEntityOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto, ThirdTestEntityZeroOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto, ThirdTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommandHandlerBase<CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommand>
{
	public CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto, ThirdTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommandHandlerBase<DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommand>
{
	public DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommand(ThirdTestEntityOneOrManyKeyDto EntityKeyDto)
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommandHandler
	: RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommandHandlerBase<DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommand>
{
	public DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManyRelationshipCommandHandlerBase(
		TestWebAppDbContext dbContext,
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
		OnExecuting(request);
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
				entity.CreateRefToThirdTestEntityZeroOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToThirdTestEntityZeroOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.ThirdTestEntityZeroOrManyRelationship).LoadAsync();
				entity.DeleteAllRefToThirdTestEntityZeroOrManyRelationship();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}