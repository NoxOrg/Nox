
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
using SecondTestEntityZeroOrOneEntity = TestWebApp.Domain.SecondTestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase<CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand>
{
	public CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase<DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand>
{
	public DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(SecondTestEntityZeroOrOneKeyDto EntityKeyDto)
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler
	: RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase<DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand>
{
	public DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.SecondTestEntityZeroOrOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.SecondTestEntityZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityZeroOrOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityZeroOrOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityZeroOrOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityZeroOrOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestEntityZeroOrOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}