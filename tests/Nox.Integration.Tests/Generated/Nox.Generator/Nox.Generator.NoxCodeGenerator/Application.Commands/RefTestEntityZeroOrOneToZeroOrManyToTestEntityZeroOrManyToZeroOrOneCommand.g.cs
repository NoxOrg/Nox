
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
using TestEntityZeroOrOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(TestEntityZeroOrOneToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToZeroOrOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(TestEntityZeroOrOneToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandlerBase<CreateRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand>
{
	public CreateRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(TestEntityZeroOrOneToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandlerBase<DeleteRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand>
{
	public DeleteRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(TestEntityZeroOrOneToZeroOrManyKeyDto EntityKeyDto)
	: RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandlerBase<DeleteAllRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand>
{
	public DeleteAllRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrOneToZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityZeroOrOneToZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityZeroOrManyToZeroOrOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityZeroOrManyToZeroOrOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityZeroOrManyToZeroOrOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestEntityZeroOrManyToZeroOrOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}