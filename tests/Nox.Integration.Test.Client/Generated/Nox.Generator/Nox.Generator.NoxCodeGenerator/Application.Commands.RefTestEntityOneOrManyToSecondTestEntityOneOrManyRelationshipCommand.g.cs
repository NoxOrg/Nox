
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

public abstract record RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandlerBase<CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand>
{
	public CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(TestEntityOneOrManyKeyDto EntityKeyDto, SecondTestEntityOneOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandlerBase<DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand>
{
	public DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(TestEntityOneOrManyKeyDto EntityKeyDto)
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandler
	: RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandlerBase<DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand>
{
	public DeleteAllRefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityOneOrMany>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityOneOrManyToSecondTestEntityOneOrManyRelationshipCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<TestEntityOneOrMany, Nox.Types.Text>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityOneOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		SecondTestEntityOneOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<SecondTestEntityOneOrMany, Nox.Types.Text>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.SecondTestEntityOneOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToSecondTestEntityOneOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToSecondTestEntityOneOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.SecondTestEntityOneOrManyRelationship).LoadAsync();
				entity.DeleteAllRefToSecondTestEntityOneOrManyRelationship();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}