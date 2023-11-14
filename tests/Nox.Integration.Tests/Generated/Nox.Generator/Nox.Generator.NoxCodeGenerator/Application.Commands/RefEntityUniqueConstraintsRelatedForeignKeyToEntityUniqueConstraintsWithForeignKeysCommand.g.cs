
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
using EntityUniqueConstraintsRelatedForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey;

namespace TestWebApp.Application.Commands;

public abstract record RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsWithForeignKeyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsWithForeignKeyKeyDto RelatedEntityKeyDto)
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand>
{
	public CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsWithForeignKeyKeyDto RelatedEntityKeyDto)
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand>
{
	public DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto)
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityKeyDto, null);

internal partial class DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand>
{
	public DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<TRequest> : CommandBase<TRequest, EntityUniqueConstraintsRelatedForeignKeyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.EntityUniqueConstraintsRelatedForeignKeys.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.EntityUniqueConstraintsWithForeignKeys.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToEntityUniqueConstraintsWithForeignKeys(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToEntityUniqueConstraintsWithForeignKeys(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.EntityUniqueConstraintsWithForeignKeys).LoadAsync();
				entity.DeleteAllRefToEntityUniqueConstraintsWithForeignKeys();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}