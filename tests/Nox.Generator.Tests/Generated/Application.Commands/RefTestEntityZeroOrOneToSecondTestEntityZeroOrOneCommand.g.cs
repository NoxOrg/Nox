
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

public abstract record RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(TestEntityZeroOrOneKeyDto EntityKeyDto, SecondTestEntityZeroOrOneKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(TestEntityZeroOrOneKeyDto EntityKeyDto, SecondTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase<CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand>
{
	public CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(TestEntityZeroOrOneKeyDto EntityKeyDto, SecondTestEntityZeroOrOneKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase<DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand>
{
	public DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(TestEntityZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler
	: RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase<DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand>
{
	public DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommandHandlerBase(
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
				entity.CreateRefToSecondTestEntityZeroOrOne(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToSecondTestEntityZeroOrOne(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToSecondTestEntityZeroOrOne();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}