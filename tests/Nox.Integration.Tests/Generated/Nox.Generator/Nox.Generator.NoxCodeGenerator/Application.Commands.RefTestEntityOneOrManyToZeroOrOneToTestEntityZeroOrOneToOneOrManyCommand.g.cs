
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

public abstract record RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToOneOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommandHandler
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommandHandlerBase<CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand>
{
	public CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommandHandler
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommandHandlerBase<DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand>
{
	public DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand(TestEntityOneOrManyToZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommandHandler
	: RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand>
{
	public DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrManyToZeroOrOne>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityOneOrManyToZeroOrOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityOneOrManyToZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestEntityZeroOrOneToOneOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrOneToOneOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityZeroOrOneToOneOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityZeroOrOneToOneOrMany(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityZeroOrOneToOneOrMany(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrOneToOneOrMany).LoadAsync();
				entity.DeleteAllRefToTestEntityZeroOrOneToOneOrMany();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}