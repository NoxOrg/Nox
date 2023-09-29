
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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;

public abstract record RefStoreToOwnershipCommand(StoreKeyDto EntityKeyDto, StoreOwnerKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefStoreToOwnershipCommand(StoreKeyDto EntityKeyDto, StoreOwnerKeyDto RelatedEntityKeyDto)
	: RefStoreToOwnershipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefStoreToOwnershipCommandHandler
	: RefStoreToOwnershipCommandHandlerBase<CreateRefStoreToOwnershipCommand>
{
	public CreateRefStoreToOwnershipCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefStoreToOwnershipCommand(StoreKeyDto EntityKeyDto, StoreOwnerKeyDto RelatedEntityKeyDto)
	: RefStoreToOwnershipCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefStoreToOwnershipCommandHandler
	: RefStoreToOwnershipCommandHandlerBase<DeleteRefStoreToOwnershipCommand>
{
	public DeleteRefStoreToOwnershipCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefStoreToOwnershipCommand(StoreKeyDto EntityKeyDto)
	: RefStoreToOwnershipCommand(EntityKeyDto, null);

internal partial class DeleteAllRefStoreToOwnershipCommandHandler
	: RefStoreToOwnershipCommandHandlerBase<DeleteAllRefStoreToOwnershipCommand>
{
	public DeleteAllRefStoreToOwnershipCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefStoreToOwnershipCommandHandlerBase<TRequest> : CommandBase<TRequest, Store>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToOwnershipCommand
{
	public ClientApiDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefStoreToOwnershipCommandHandlerBase(
		ClientApiDbContext dbContext,
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
		var keyId = CreateNoxTypeForKey<Store, Nox.Types.Guid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		StoreOwner? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<StoreOwner, Nox.Types.Text>("Id", request.RelatedEntityKeyDto.keyId);
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

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}