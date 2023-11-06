
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
using TestEntityZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommand(TestEntityZeroOrOneKeyDto EntityKeyDto, SecondTestEntityZeroOrOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommand(TestEntityZeroOrOneKeyDto EntityKeyDto, SecondTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommandHandler
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommandHandlerBase<CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommand>
{
	public CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommand(TestEntityZeroOrOneKeyDto EntityKeyDto, SecondTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommandHandler
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommandHandlerBase<DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommand>
{
	public DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommand(TestEntityZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommandHandler
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommandHandlerBase<DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommand>
{
	public DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneRelationshipCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.SecondTestEntityZeroOrOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.SecondTestEntityZeroOrOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.SecondTestEntityZeroOrOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToSecondTestEntityZeroOrOneRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToSecondTestEntityZeroOrOneRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToSecondTestEntityZeroOrOneRelationship();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}