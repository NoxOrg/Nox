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
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public partial record CreateStoreCommand(StoreCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<StoreKeyDto>;

internal partial class CreateStoreCommandHandler : CreateStoreCommandHandlerBase
{
	public CreateStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> StoreOwnerFactory,
		IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory,
		IEntityFactory<ClientApi.Domain.Client, ClientCreateDto, ClientUpdateDto> ClientFactory,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory)
		: base(dbContext, noxSolution,StoreOwnerFactory, StoreLicenseFactory, ClientFactory, entityFactory)
	{
	}
}


internal abstract class CreateStoreCommandHandlerBase : CommandBase<CreateStoreCommand,StoreEntity>, IRequestHandler <CreateStoreCommand, StoreKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> StoreOwnerFactory;
	protected readonly IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Client, ClientCreateDto, ClientUpdateDto> ClientFactory;

	protected CreateStoreCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> StoreOwnerFactory,
		IEntityFactory<ClientApi.Domain.StoreLicense, StoreLicenseCreateDto, StoreLicenseUpdateDto> StoreLicenseFactory,
		IEntityFactory<ClientApi.Domain.Client, ClientCreateDto, ClientUpdateDto> ClientFactory,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.StoreOwnerFactory = StoreOwnerFactory;
		this.StoreLicenseFactory = StoreLicenseFactory;
		this.ClientFactory = ClientFactory;
	}

	public virtual async Task<StoreKeyDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto);
		if(request.EntityDto.StoreOwnerId is not null)
		{
			var relatedKey = ClientApi.Domain.StoreOwnerMetadata.CreateId(request.EntityDto.StoreOwnerId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.StoreOwners.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToStoreOwner(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("StoreOwner", request.EntityDto.StoreOwnerId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.StoreOwner is not null)
		{
			var relatedEntity = await StoreOwnerFactory.CreateEntityAsync(request.EntityDto.StoreOwner);
			entityToCreate.CreateRefToStoreOwner(relatedEntity);
		}
		if(request.EntityDto.StoreLicenseId is not null)
		{
			var relatedKey = ClientApi.Domain.StoreLicenseMetadata.CreateId(request.EntityDto.StoreLicenseId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.StoreLicenses.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToStoreLicense(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("StoreLicense", request.EntityDto.StoreLicenseId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.StoreLicense is not null)
		{
			var relatedEntity = await StoreLicenseFactory.CreateEntityAsync(request.EntityDto.StoreLicense);
			entityToCreate.CreateRefToStoreLicense(relatedEntity);
		}
		if(request.EntityDto.ClientsId.Any())
		{
			foreach(var relatedId in request.EntityDto.ClientsId)
			{
				var relatedKey = ClientApi.Domain.ClientMetadata.CreateId(relatedId);
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
				var relatedEntity = await ClientFactory.CreateEntityAsync(relatedCreateDto);
				entityToCreate.CreateRefToClients(relatedEntity);
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