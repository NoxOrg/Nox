
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

public abstract record RefStoreToStoreOwnerCommand(StoreKeyDto EntityKeyDto, StoreOwnerKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefStoreToStoreOwnerCommand(StoreKeyDto EntityKeyDto, StoreOwnerKeyDto RelatedEntityKeyDto)
	: RefStoreToStoreOwnerCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefStoreToStoreOwnerCommandHandler
	: RefStoreToStoreOwnerCommandHandlerBase<CreateRefStoreToStoreOwnerCommand>
{
	public CreateRefStoreToStoreOwnerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefStoreToStoreOwnerCommand(StoreKeyDto EntityKeyDto, StoreOwnerKeyDto RelatedEntityKeyDto)
	: RefStoreToStoreOwnerCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefStoreToStoreOwnerCommandHandler
	: RefStoreToStoreOwnerCommandHandlerBase<DeleteRefStoreToStoreOwnerCommand>
{
	public DeleteRefStoreToStoreOwnerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefStoreToStoreOwnerCommand(StoreKeyDto EntityKeyDto)
	: RefStoreToStoreOwnerCommand(EntityKeyDto, null);

internal partial class DeleteAllRefStoreToStoreOwnerCommandHandler
	: RefStoreToStoreOwnerCommandHandlerBase<DeleteAllRefStoreToStoreOwnerCommand>
{
	public DeleteAllRefStoreToStoreOwnerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefStoreToStoreOwnerCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToStoreOwnerCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefStoreToStoreOwnerCommandHandlerBase(
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
				entity.CreateRefToStoreOwner(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToStoreOwner(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToStoreOwner();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}