
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

public abstract record RefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreOwnerToStoresCommand(EntityKeyDto);

internal partial class CreateRefStoreOwnerToStoresCommandHandler
	: RefStoreOwnerToStoresCommandHandlerBase<CreateRefStoreOwnerToStoresCommand>
{
	public CreateRefStoreOwnerToStoresCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefStoreOwnerToStoresCommand request)
    {
		var entity = await GetStoreOwner(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetStore(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToStores(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto, List<StoreKeyDto> RelatedEntitiesKeysDtos)
	: RefStoreOwnerToStoresCommand(EntityKeyDto);

internal partial class UpdateRefStoreOwnerToStoresCommandHandler
	: RefStoreOwnerToStoresCommandHandlerBase<UpdateRefStoreOwnerToStoresCommand>
{
	public UpdateRefStoreOwnerToStoresCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefStoreOwnerToStoresCommand request)
    {
		var entity = await GetStoreOwner(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<ClientApi.Domain.Store>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetStore(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Stores).LoadAsync();
		entity.UpdateRefToStores(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreOwnerToStoresCommand(EntityKeyDto);

internal partial class DeleteRefStoreOwnerToStoresCommandHandler
	: RefStoreOwnerToStoresCommandHandlerBase<DeleteRefStoreOwnerToStoresCommand>
{
	public DeleteRefStoreOwnerToStoresCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefStoreOwnerToStoresCommand request)
    {
        var entity = await GetStoreOwner(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetStore(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToStores(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto)
	: RefStoreOwnerToStoresCommand(EntityKeyDto);

internal partial class DeleteAllRefStoreOwnerToStoresCommandHandler
	: RefStoreOwnerToStoresCommandHandlerBase<DeleteAllRefStoreOwnerToStoresCommand>
{
	public DeleteAllRefStoreOwnerToStoresCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefStoreOwnerToStoresCommand request)
    {
        var entity = await GetStoreOwner(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.Stores).LoadAsync();
		entity.DeleteAllRefToStores();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreOwnerToStoresCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreOwnerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreOwnerToStoresCommand
{
	public AppDbContext DbContext { get; }

	public RefStoreOwnerToStoresCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<StoreOwnerEntity?> GetStoreOwner(StoreOwnerKeyDto entityKeyDto)
	{
		var keyId = ClientApi.Domain.StoreOwnerMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.StoreOwners.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.Store?> GetStore(StoreKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = ClientApi.Domain.StoreMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Stores.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, StoreOwnerEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}