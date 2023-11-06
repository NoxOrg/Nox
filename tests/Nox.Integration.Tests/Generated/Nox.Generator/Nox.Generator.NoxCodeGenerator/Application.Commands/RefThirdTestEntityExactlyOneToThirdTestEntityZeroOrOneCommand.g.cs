
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
using ThirdTestEntityExactlyOneEntity = TestWebApp.Domain.ThirdTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(ThirdTestEntityExactlyOneKeyDto EntityKeyDto, ThirdTestEntityZeroOrOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(ThirdTestEntityExactlyOneKeyDto EntityKeyDto, ThirdTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandler
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandlerBase<CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand>
{
	public CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(ThirdTestEntityExactlyOneKeyDto EntityKeyDto, ThirdTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandler
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandlerBase<DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand>
{
	public DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(ThirdTestEntityExactlyOneKeyDto EntityKeyDto)
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandler
	: RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandlerBase<DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand>
{
	public DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, ThirdTestEntityExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.ThirdTestEntityExactlyOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.ThirdTestEntityExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.ThirdTestEntityZeroOrOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.ThirdTestEntityZeroOrOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.ThirdTestEntityZeroOrOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToThirdTestEntityZeroOrOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToThirdTestEntityZeroOrOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToThirdTestEntityZeroOrOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}