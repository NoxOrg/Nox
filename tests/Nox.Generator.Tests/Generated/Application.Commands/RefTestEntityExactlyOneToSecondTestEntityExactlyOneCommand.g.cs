
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
using TestEntityExactlyOneEntity = TestWebApp.Domain.TestEntityExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(TestEntityExactlyOneKeyDto EntityKeyDto, SecondTestEntityExactlyOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(TestEntityExactlyOneKeyDto EntityKeyDto, SecondTestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase<CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand>
{
	public CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(TestEntityExactlyOneKeyDto EntityKeyDto, SecondTestEntityExactlyOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase<DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand>
{
	public DeleteRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(TestEntityExactlyOneKeyDto EntityKeyDto)
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler
	: RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase<DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand>
{
	public DeleteAllRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityExactlyOneToSecondTestEntityExactlyOneCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityExactlyOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.SecondTestEntityExactlyOne? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.SecondTestEntityExactlyOneMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.SecondTestEntityExactlyOnes.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToSecondTestEntityExactlyOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToSecondTestEntityExactlyOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToSecondTestEntityExactlyOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}