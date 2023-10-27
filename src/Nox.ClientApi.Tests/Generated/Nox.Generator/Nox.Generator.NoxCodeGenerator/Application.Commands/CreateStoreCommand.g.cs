﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public record CreateStoreCommand(StoreCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<StoreKeyDto>;

internal partial class CreateStoreCommandHandler : CreateStoreCommandHandlerBase
{
	public CreateStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> StoreOwnerFactory,
		IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory)
		: base(dbContext, noxSolution,StoreOwnerFactory, StoreLicenseFactory, entityFactory)
	{
	}
}


internal abstract class CreateStoreCommandHandlerBase : CommandBase<CreateStoreCommand,StoreEntity>, IRequestHandler <CreateStoreCommand, StoreKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> StoreOwnerFactory;
	protected readonly IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory;

	public CreateStoreCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> StoreOwnerFactory,
		IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.StoreOwnerFactory = StoreOwnerFactory;
		this.StoreLicenseFactory = StoreLicenseFactory;
	}

	public virtual async Task<StoreKeyDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.OwnershipId is not null)
		{
			var relatedKey = ClientApi.Domain.StoreOwnerMetadata.CreateId(request.EntityDto.OwnershipId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.StoreOwners.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToOwnership(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Ownership", request.EntityDto.OwnershipId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.Ownership is not null)
		{
			var relatedEntity = StoreOwnerFactory.CreateEntity(request.EntityDto.Ownership);
			entityToCreate.CreateRefToOwnership(relatedEntity);
		}
		if(request.EntityDto.LicenseId is not null)
		{
			var relatedKey = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.EntityDto.LicenseId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.StoreLicenses.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToLicense(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("License", request.EntityDto.LicenseId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.License is not null)
		{
			var relatedEntity = StoreLicenseFactory.CreateEntity(request.EntityDto.License);
			entityToCreate.CreateRefToLicense(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Stores.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new StoreKeyDto(entityToCreate.Id.Value);
	}
}