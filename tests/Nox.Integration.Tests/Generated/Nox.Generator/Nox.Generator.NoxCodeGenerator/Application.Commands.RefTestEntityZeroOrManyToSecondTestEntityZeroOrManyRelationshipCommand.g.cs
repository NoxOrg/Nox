
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

public abstract record RefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommand(TestEntityZeroOrManyKeyDto EntityKeyDto, SecondTestEntityZeroOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommand(TestEntityZeroOrManyKeyDto EntityKeyDto, SecondTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommandHandlerBase<CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommand>
{
	public CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommand(TestEntityZeroOrManyKeyDto EntityKeyDto, SecondTestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommandHandlerBase<DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommand>
{
	public DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommand(TestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommandHandler
	: RefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommandHandlerBase<DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommand>
{
	public DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, TestEntityZeroOrMany>,
	IRequestHandler <TRequest, bool> where TRequest : RefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTestEntityZeroOrManyToSecondTestEntityZeroOrManyRelationshipCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<TestEntityZeroOrMany, Nox.Types.Text>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.TestEntityZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		SecondTestEntityZeroOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<SecondTestEntityZeroOrMany, Nox.Types.Text>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.SecondTestEntityZeroOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToSecondTestEntityZeroOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToSecondTestEntityZeroOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.SecondTestEntityZeroOrManyRelationship).LoadAsync();
				entity.DeleteAllRefToSecondTestEntityZeroOrManyRelationship();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}