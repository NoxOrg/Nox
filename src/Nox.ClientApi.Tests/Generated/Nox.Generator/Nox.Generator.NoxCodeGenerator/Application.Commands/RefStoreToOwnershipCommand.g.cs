
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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public abstract record RefStoreToOwnershipCommand(StoreKeyDto EntityKeyDto, StoreOwnerKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefStoreToOwnershipCommand(StoreKeyDto EntityKeyDto, StoreOwnerKeyDto RelatedEntityKeyDto)
	: RefStoreToOwnershipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefStoreToOwnershipCommandHandler
	: RefStoreToOwnershipCommandHandlerBase<CreateRefStoreToOwnershipCommand>
{
	public CreateRefStoreToOwnershipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefStoreToOwnershipCommand(StoreKeyDto EntityKeyDto, StoreOwnerKeyDto RelatedEntityKeyDto)
	: RefStoreToOwnershipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefStoreToOwnershipCommandHandler
	: RefStoreToOwnershipCommandHandlerBase<DeleteRefStoreToOwnershipCommand>
{
	public DeleteRefStoreToOwnershipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefStoreToOwnershipCommand(StoreKeyDto EntityKeyDto)
	: RefStoreToOwnershipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefStoreToOwnershipCommandHandler
	: RefStoreToOwnershipCommandHandlerBase<DeleteAllRefStoreToOwnershipCommand>
{
	public DeleteAllRefStoreToOwnershipCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefStoreToOwnershipCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToOwnershipCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefStoreToOwnershipCommandHandlerBase(
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
		var keyId = ClientApi.Domain.StoreMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		ClientApi.Domain.StoreOwner? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = ClientApi.Domain.StoreOwnerMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.StoreOwners.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToOwnership(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToOwnership(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToOwnership();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}