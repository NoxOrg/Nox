
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
using TestEntityZeroOrManyToZeroOrOneEntity = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne;

namespace TestWebApp.Application.Commands;

public abstract record RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToZeroOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommandHandler
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommandHandlerBase<CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommand>
{
	public CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto, TestEntityZeroOrOneToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommandHandler
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommandHandlerBase<DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommand>
{
	public DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommand(TestEntityZeroOrManyToZeroOrOneKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommandHandler
	: RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyToZeroOrOneEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManyCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityZeroOrManyToZeroOrOnes.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityZeroOrOneToZeroOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityZeroOrOneToZeroOrMany(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityZeroOrOneToZeroOrMany(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrOneToZeroOrMany).LoadAsync();
				entity.DeleteAllRefToTestEntityZeroOrOneToZeroOrMany();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}