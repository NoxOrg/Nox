
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
using TestEntityZeroOrOneToOneOrManyEntity = TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(TestEntityZeroOrOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(TestEntityZeroOrOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase<CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand>
{
	public CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(TestEntityZeroOrOneToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase<DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand>
{
	public DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(TestEntityZeroOrOneToOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase<DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand>
{
	public DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrOneToOneOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityZeroOrOneToOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityOneOrManyToZeroOrOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityOneOrManyToZeroOrOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityOneOrManyToZeroOrOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestEntityOneOrManyToZeroOrOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}