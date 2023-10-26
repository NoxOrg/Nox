
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
using ThirdTestEntityZeroOrOneEntity = TestWebApp.Domain.ThirdTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand(ThirdTestEntityZeroOrOneKeyDto EntityKeyDto, ThirdTestEntityExactlyOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand(ThirdTestEntityZeroOrOneKeyDto EntityKeyDto, ThirdTestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommandHandler
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommandHandlerBase<CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand>
{
	public CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand(ThirdTestEntityZeroOrOneKeyDto EntityKeyDto, ThirdTestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommandHandler
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommandHandlerBase<DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand>
{
	public DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand(ThirdTestEntityZeroOrOneKeyDto EntityKeyDto)
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommandHandler
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommandHandlerBase<DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand>
{
	public DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommandHandlerBase(
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
		OnExecuting(request);
		var keyId = TestWebApp.Domain.ThirdTestEntityZeroOrOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.ThirdTestEntityZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.ThirdTestEntityExactlyOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.ThirdTestEntityExactlyOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.ThirdTestEntityExactlyOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToThirdTestEntityExactlyOneRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToThirdTestEntityExactlyOneRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToThirdTestEntityExactlyOneRelationship();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}