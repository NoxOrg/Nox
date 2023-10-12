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
using Nox.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public record CreateStoreCommand(StoreCreateDto EntityDto) : IRequest<StoreKeyDto>;

internal partial class CreateStoreCommandHandler : CreateStoreCommandHandlerBase
{
	public CreateStoreCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> storeownerfactory,
		IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> storelicensefactory,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory)
		: base(dbContext, noxSolution,storeownerfactory, storelicensefactory, entityFactory)
	{
	}
}


internal abstract class CreateStoreCommandHandlerBase : CommandBase<CreateStoreCommand,StoreEntity>, IRequestHandler <CreateStoreCommand, StoreKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> _entityFactory;
	private readonly IEntityFactory<ClientApi.Domain.StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> _storeownerfactory;
	private readonly IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> _storelicensefactory;

	public CreateStoreCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> storeownerfactory,
		IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> storelicensefactory,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_storeownerfactory = storeownerfactory;
		_storelicensefactory = storelicensefactory;
	}

	public virtual async Task<StoreKeyDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.OwnershipId is not null)
		{
			var relatedKey = ClientApi.Domain.StoreOwnerMetadata.CreateId(request.EntityDto.OwnershipId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.StoreOwners.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToOwnership(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Ownership", request.EntityDto.OwnershipId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.Ownership is not null)
		{
			var relatedEntity = _storeownerfactory.CreateEntity(request.EntityDto.Ownership);
			entityToCreate.CreateRefToOwnership(relatedEntity);
		}
		if(request.EntityDto.LicenseId is not null)
		{
			var relatedKey = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.EntityDto.LicenseId.NonNullValue<System.Int64>());
			var relatedEntity = await _dbContext.StoreLicenses.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToLicense(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("License", request.EntityDto.LicenseId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.License is not null)
		{
			var relatedEntity = _storelicensefactory.CreateEntity(request.EntityDto.License);
			entityToCreate.CreateRefToLicense(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.Stores.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new StoreKeyDto(entityToCreate.Id.Value);
	}
}