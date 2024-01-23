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
using Nox.Exceptions;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
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
			throw new EntityNotFoundException("StoreOwner",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStores(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
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
			throw new EntityNotFoundException("StoreOwner",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Store>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetStores(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Store", $"{keyDto.keyId.ToString()}");
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
			throw new EntityNotFoundException("StoreOwner",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStores(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
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
			throw new EntityNotFoundException("StoreOwner",  $"{request.EntityKeyDto.keyId.ToString()}");
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
		var keyId = Dto.StoreOwnerMetadata.CreateId(entityKeyDto.keyId);
		var entity = await DbContext.StoreOwners.FindAsync(keyId);
		if(entity is not null)
		{
			await DbContext.Entry(entity).Collection(x => x.Stores).LoadAsync();
		}

		return entity;
	}

	protected async Task<ClientApi.Domain.Store?> GetStores(StoreKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.StoreMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Stores.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, StoreOwnerEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}