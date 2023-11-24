
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
using TestEntityExactlyOneToZeroOrManyEntity = TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(TestEntityExactlyOneToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToExactlyOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(TestEntityExactlyOneToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandlerBase<CreateRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand>
{
	public CreateRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(TestEntityExactlyOneToZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyToExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandlerBase<DeleteRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand>
{
	public DeleteRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(TestEntityExactlyOneToZeroOrManyKeyDto EntityKeyDto)
	: RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandler
	: RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandlerBase<DeleteAllRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand>
{
	public DeleteAllRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityExactlyOneToZeroOrManyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityExactlyOneToZeroOrManyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityExactlyOneToZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityZeroOrManyToExactlyOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityZeroOrManyToExactlyOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityZeroOrManyToExactlyOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTestEntityZeroOrManyToExactlyOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}