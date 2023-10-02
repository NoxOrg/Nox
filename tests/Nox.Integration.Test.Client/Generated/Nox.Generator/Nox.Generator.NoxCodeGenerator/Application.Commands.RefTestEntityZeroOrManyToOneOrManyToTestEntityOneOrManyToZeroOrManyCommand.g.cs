
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

public abstract record RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommandHandler
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommandHandlerBase<CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommand>
{
	public CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto, TestEntityOneOrManyToZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommandHandler
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommandHandlerBase<DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommand>
{
	public DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommand(TestEntityZeroOrManyToOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommandHandler
	: RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrManyToOneOrMany>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManyCommandHandlerBase(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		RelationshipAction action)
		: base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<TestEntityZeroOrManyToOneOrMany, Nox.Types.Text>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityZeroOrManyToOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestEntityOneOrManyToZeroOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<TestEntityOneOrManyToZeroOrMany, Nox.Types.Text>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityOneOrManyToZeroOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityOneOrManyToZeroOrMany(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityOneOrManyToZeroOrMany(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityOneOrManyToZeroOrMany).LoadAsync();
				entity.DeleteAllRefToTestEntityOneOrManyToZeroOrMany();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}