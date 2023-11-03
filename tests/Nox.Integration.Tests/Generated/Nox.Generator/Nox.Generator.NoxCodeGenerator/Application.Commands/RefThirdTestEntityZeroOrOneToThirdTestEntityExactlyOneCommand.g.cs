
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

public abstract record RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(ThirdTestEntityZeroOrOneKeyDto EntityKeyDto, ThirdTestEntityExactlyOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(ThirdTestEntityZeroOrOneKeyDto EntityKeyDto, ThirdTestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandler
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandlerBase<CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand>
{
	public CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(ThirdTestEntityZeroOrOneKeyDto EntityKeyDto, ThirdTestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandler
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandlerBase<DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand>
{
	public DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(ThirdTestEntityZeroOrOneKeyDto EntityKeyDto)
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandler
	: RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandlerBase<DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand>
{
	public DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneCommandHandlerBase(
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
				entity.CreateRefToThirdTestEntityExactlyOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToThirdTestEntityExactlyOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToThirdTestEntityExactlyOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}