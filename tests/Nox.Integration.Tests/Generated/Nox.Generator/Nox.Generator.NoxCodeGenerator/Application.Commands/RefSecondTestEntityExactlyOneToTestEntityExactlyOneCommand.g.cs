
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
using SecondTestEntityExactlyOneEntity = TestWebApp.Domain.SecondTestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase<CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand>
{
	public CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase<DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand>
{
	public DeleteRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(SecondTestEntityExactlyOneKeyDto EntityKeyDto)
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler
	: RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase<DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand>
{
	public DeleteAllRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefSecondTestEntityExactlyOneToTestEntityExactlyOneCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.SecondTestEntityExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityExactlyOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityExactlyOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityExactlyOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityExactlyOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityExactlyOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestEntityExactlyOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}