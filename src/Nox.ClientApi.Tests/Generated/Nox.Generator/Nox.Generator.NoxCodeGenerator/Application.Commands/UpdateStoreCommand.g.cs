﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public record UpdateStoreCommand(System.Guid keyId, StoreUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<StoreKeyDto?>;

internal partial class UpdateStoreCommandHandler : UpdateStoreCommandHandlerBase
{
	public UpdateStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateStoreCommandHandlerBase : CommandBase<UpdateStoreCommand, StoreEntity>, IRequestHandler<UpdateStoreCommand, StoreKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> _entityFactory;

	public UpdateStoreCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<StoreKeyDto?> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.StoreMetadata.CreateId(request.keyId);

		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		if(request.EntityDto.StoreOwnerId is not null)
		{
			var storeOwnerKey = ClientApi.Domain.StoreOwnerMetadata.CreateId(request.EntityDto.StoreOwnerId.NonNullValue<System.String>());
			var storeOwnerEntity = await DbContext.StoreOwners.FindAsync(storeOwnerKey);
						
			if(storeOwnerEntity is not null)
				entity.CreateRefToStoreOwner(storeOwnerEntity);
			else
				throw new RelatedEntityNotFoundException("StoreOwner", request.EntityDto.StoreOwnerId.NonNullValue<System.String>().ToString());
		}
		else
		{
			entity.DeleteAllRefToStoreOwner();
		}

		if(request.EntityDto.StoreLicenseId is not null)
		{
			var storeLicenseKey = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.EntityDto.StoreLicenseId.NonNullValue<System.Int64>());
			var storeLicenseEntity = await DbContext.StoreLicenses.FindAsync(storeLicenseKey);
						
			if(storeLicenseEntity is not null)
				entity.CreateRefToStoreLicense(storeLicenseEntity);
			else
				throw new RelatedEntityNotFoundException("StoreLicense", request.EntityDto.StoreLicenseId.NonNullValue<System.Int64>().ToString());
		}
		else
		{
			entity.DeleteAllRefToStoreLicense();
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new StoreKeyDto(entity.Id.Value);
	}
}