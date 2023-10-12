
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
using TestEntityExactlyOneToZeroOrOneEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(TestEntityExactlyOneToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToExactlyOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(TestEntityExactlyOneToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase<CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand>
{
	public CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(TestEntityExactlyOneToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase<DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand>
{
	public DeleteRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(TestEntityExactlyOneToZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase<DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand>
{
	public DeleteAllRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityExactlyOneToZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityExactlyOneToZeroOrOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityExactlyOneToZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrOneToExactlyOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityZeroOrOneToExactlyOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityZeroOrOneToExactlyOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestEntityZeroOrOneToExactlyOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}