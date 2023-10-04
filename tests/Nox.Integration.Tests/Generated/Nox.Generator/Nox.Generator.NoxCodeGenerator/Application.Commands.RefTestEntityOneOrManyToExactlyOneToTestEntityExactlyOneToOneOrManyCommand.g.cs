
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
using TestEntityOneOrManyToExactlyOneEntity = TestWebApp.Domain.TestEntityOneOrManyToExactlyOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToOneOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommandHandler
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommandHandlerBase<CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommand>
{
	public CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto, TestEntityExactlyOneToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommandHandler
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommandHandlerBase<DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommand>
{
	public DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommand(TestEntityOneOrManyToExactlyOneKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommandHandler
	: RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommand>
{
	public DeleteAllRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyToExactlyOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManyCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToExactlyOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityOneOrManyToExactlyOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityExactlyOneToOneOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityExactlyOneToOneOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityExactlyOneToOneOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityExactlyOneToOneOrMany(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityExactlyOneToOneOrMany(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityExactlyOneToOneOrMany).LoadAsync();
				entity.DeleteAllRefToTestEntityExactlyOneToOneOrMany();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}