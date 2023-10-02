
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

public abstract record RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandlerBase<CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand>
{
	public CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto, TestEntityZeroOrManyKeyDto RelatedEntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandlerBase<DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand>
{
	public DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(SecondTestEntityZeroOrManyKeyDto EntityKeyDto)
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandler
	: RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandlerBase<DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand>
{
	public DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandler(
		TestWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandlerBase<TRequest> : CommandBase<TRequest, SecondTestEntityZeroOrMany>,
	IRequestHandler <TRequest, bool> where TRequest : RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommand
{
	public TestWebAppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefSecondTestEntityZeroOrManyToTestEntityZeroOrManyRelationshipCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<SecondTestEntityZeroOrMany, Nox.Types.Text>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.SecondTestEntityZeroOrManies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestEntityZeroOrMany? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<TestEntityZeroOrMany, Nox.Types.Text>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.TestEntityZeroOrManies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTestEntityZeroOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTestEntityZeroOrManyRelationship(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.TestEntityZeroOrManyRelationship).LoadAsync();
				entity.DeleteAllRefToTestEntityZeroOrManyRelationship();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}