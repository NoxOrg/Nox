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

public partial record UpdateStoreCommand(System.Guid keyId, StoreUpdateDto EntityDto, System.Guid? Etag) : IRequest<StoreKeyDto?>;

internal partial class UpdateStoreCommandHandler : UpdateStoreCommandHandlerBase
{
	public UpdateStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
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
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory) : base(noxSolution)
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

		if(request.EntityDto.OwnershipId is not null)
		{
			var ownershipKey = ClientApi.Domain.StoreOwnerMetadata.CreateId(request.EntityDto.OwnershipId.NonNullValue<System.String>());
			var ownershipEntity = await DbContext.StoreOwners.FindAsync(ownershipKey);
						
			if(ownershipEntity is not null)
				entity.CreateRefToOwnership(ownershipEntity);
			else
				throw new RelatedEntityNotFoundException("Ownership", request.EntityDto.OwnershipId.NonNullValue<System.String>().ToString());
		}
		else
		{
			entity.DeleteAllRefToOwnership();
		}

		if(request.EntityDto.LicenseId is not null)
		{
			var licenseKey = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.EntityDto.LicenseId.NonNullValue<System.Int64>());
			var licenseEntity = await DbContext.StoreLicenses.FindAsync(licenseKey);
						
			if(licenseEntity is not null)
				entity.CreateRefToLicense(licenseEntity);
			else
				throw new RelatedEntityNotFoundException("License", request.EntityDto.LicenseId.NonNullValue<System.Int64>().ToString());
		}
		else
		{
			entity.DeleteAllRefToLicense();
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
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