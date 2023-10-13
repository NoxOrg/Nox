
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
using StoreOwnerEntity = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public abstract record RefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto, StoreKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreOwnerToStoresCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefStoreOwnerToStoresCommandHandler
	: RefStoreOwnerToStoresCommandHandlerBase<CreateRefStoreOwnerToStoresCommand>
{
	public CreateRefStoreOwnerToStoresCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreOwnerToStoresCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefStoreOwnerToStoresCommandHandler
	: RefStoreOwnerToStoresCommandHandlerBase<DeleteRefStoreOwnerToStoresCommand>
{
	public DeleteRefStoreOwnerToStoresCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto)
	: RefStoreOwnerToStoresCommand(EntityKeyDto, null);

internal partial class DeleteAllRefStoreOwnerToStoresCommandHandler
	: RefStoreOwnerToStoresCommandHandlerBase<DeleteAllRefStoreOwnerToStoresCommand>
{
	public DeleteAllRefStoreOwnerToStoresCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefStoreOwnerToStoresCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreOwnerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreOwnerToStoresCommand
{
	public ClientApiDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefStoreOwnerToStoresCommandHandlerBase(
		ClientApiDbContext dbContext,
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
		var keyId = ClientApi.Domain.StoreOwnerMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.StoreOwners.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		ClientApi.Domain.Store? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = ClientApi.Domain.StoreMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Stores.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToStores(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToStores(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.Stores).LoadAsync();
				entity.DeleteAllRefToStores();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}