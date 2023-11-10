﻿﻿// Generated

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
using StoreOwnerEntity = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public record UpdateStoreOwnerCommand(System.String keyId, StoreOwnerUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<StoreOwnerKeyDto?>;

internal partial class UpdateStoreOwnerCommandHandler : UpdateStoreOwnerCommandHandlerBase
{
	public UpdateStoreOwnerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateStoreOwnerCommandHandlerBase : CommandBase<UpdateStoreOwnerCommand, StoreOwnerEntity>, IRequestHandler<UpdateStoreOwnerCommand, StoreOwnerKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> _entityFactory;

	public UpdateStoreOwnerCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<StoreOwnerKeyDto?> Handle(UpdateStoreOwnerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.StoreOwnerMetadata.CreateId(request.keyId);

		var entity = await DbContext.StoreOwners.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.Stores).LoadAsync();
		var storesEntities = new List<ClientApi.Domain.Store>();
		foreach(var relatedEntityId in request.EntityDto.StoresId)
		{
			var relatedKey = ClientApi.Domain.StoreMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Stores.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				storesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Stores", relatedEntityId.ToString());
		}
		entity.UpdateRefToStores(storesEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new StoreOwnerKeyDto(entity.Id.Value);
	}
}