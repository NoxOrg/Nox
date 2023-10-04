
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

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommandHandlerBase<CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommand>
{
	public CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommandHandlerBase<DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommand>
{
	public DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommand(TestEntityZeroOrManyToExactlyOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommandHandler
	: RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyToExactlyOne>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManyCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToExactlyOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityZeroOrManyToExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestEntityExactlyOneToZeroOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityExactlyOneToZeroOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityExactlyOneToZeroOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityExactlyOneToZeroOrMany(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityExactlyOneToZeroOrMany(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityExactlyOneToZeroOrMany).LoadAsync();
				entity.DeleteAllRefToTestEntityExactlyOneToZeroOrMany();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}