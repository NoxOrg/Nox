
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
using EntityUniqueConstraintsWithForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey;

namespace TestWebApp.Application.Commands;

public abstract record RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsRelatedForeignKeyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsRelatedForeignKeyKeyDto RelatedEntityKeyDto)
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase<CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand>
{
	public CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsRelatedForeignKeyKeyDto RelatedEntityKeyDto)
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase<DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand>
{
	public DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyKeyDto EntityKeyDto)
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase<DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand>
{
	public DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase<TRequest> : CommandBase<TRequest, EntityUniqueConstraintsWithForeignKeyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase(
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
		var keyId = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.EntityUniqueConstraintsWithForeignKeys.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.EntityUniqueConstraintsRelatedForeignKeys.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToEntityUniqueConstraintsRelatedForeignKey(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToEntityUniqueConstraintsRelatedForeignKey(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToEntityUniqueConstraintsRelatedForeignKey();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}