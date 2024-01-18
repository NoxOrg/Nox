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
using FluentValidation;
using Microsoft.Extensions.Logging;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public partial record CreateStoreCommand(StoreCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<StoreKeyDto>;

internal partial class CreateStoreCommandHandler : CreateStoreCommandHandlerBase
{
	public CreateStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<ClientApi.Domain.StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> StoreOwnerFactory,
		IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory,
		IEntityFactory<ClientApi.Domain.Client, ClientCreateDto, ClientUpdateDto> ClientFactory,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory)
		: base(dbContext, noxSolution,CountryFactory, StoreOwnerFactory, StoreLicenseFactory, ClientFactory, StoreFactory, entityFactory)
	{
	}
}


internal abstract class CreateStoreCommandHandlerBase : CommandBase<CreateStoreCommand,StoreEntity>, IRequestHandler <CreateStoreCommand, StoreKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory;
	protected readonly IEntityFactory<ClientApi.Domain.StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> StoreOwnerFactory;
	protected readonly IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Client, ClientCreateDto, ClientUpdateDto> ClientFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory;

	protected CreateStoreCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<ClientApi.Domain.StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> StoreOwnerFactory,
		IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory,
		IEntityFactory<ClientApi.Domain.Client, ClientCreateDto, ClientUpdateDto> ClientFactory,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory)
	: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.CountryFactory = CountryFactory;
		this.StoreOwnerFactory = StoreOwnerFactory;
		this.StoreLicenseFactory = StoreLicenseFactory;
		this.ClientFactory = ClientFactory;
		this.StoreFactory = StoreFactory;
	}

	public virtual async Task<StoreKeyDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.CountryId is not null)
		{
			var relatedKey = Dto.CountryMetadata.CreateId(request.EntityDto.CountryId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.Countries.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCountry(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Country", request.EntityDto.CountryId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.Country is not null)
		{
			var relatedEntity = await CountryFactory.CreateEntityAsync(request.EntityDto.Country, request.CultureCode);
			entityToCreate.CreateRefToCountry(relatedEntity);
		}
		if(request.EntityDto.StoreOwnerId is not null)
		{
			var relatedKey = Dto.StoreOwnerMetadata.CreateId(request.EntityDto.StoreOwnerId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.StoreOwners.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToStoreOwner(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("StoreOwner", request.EntityDto.StoreOwnerId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.StoreOwner is not null)
		{
			var relatedEntity = await StoreOwnerFactory.CreateEntityAsync(request.EntityDto.StoreOwner, request.CultureCode);
			entityToCreate.CreateRefToStoreOwner(relatedEntity);
		}
		if(request.EntityDto.StoreLicenseId is not null)
		{
			var relatedKey = Dto.StoreLicenseMetadata.CreateId(request.EntityDto.StoreLicenseId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.StoreLicenses.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToStoreLicense(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("StoreLicense", request.EntityDto.StoreLicenseId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.StoreLicense is not null)
		{
			var relatedEntity = await StoreLicenseFactory.CreateEntityAsync(request.EntityDto.StoreLicense, request.CultureCode);
			entityToCreate.CreateRefToStoreLicense(relatedEntity);
		}
		if(request.EntityDto.ClientsId.Any())
		{
			foreach(var relatedId in request.EntityDto.ClientsId)
			{
				var relatedKey = Dto.ClientMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Clients.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToClients(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Clients", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Clients)
			{
				var relatedEntity = await ClientFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToClients(relatedEntity);
			}
		}
		if(request.EntityDto.StoresId.Any())
		{
			foreach(var relatedId in request.EntityDto.StoresId)
			{
				var relatedKey = Dto.StoreMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Stores.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToStores(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Stores", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Stores)
			{
				var relatedEntity = await StoreFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToStores(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Stores.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new StoreKeyDto(entityToCreate.Id.Value);
	}
}

public class CreateStoreValidator : AbstractValidator<CreateStoreCommand>
{
    public CreateStoreValidator()
    {
    }
}