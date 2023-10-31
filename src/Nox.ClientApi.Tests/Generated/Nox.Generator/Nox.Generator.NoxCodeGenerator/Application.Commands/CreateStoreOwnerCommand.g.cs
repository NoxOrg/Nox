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
using StoreOwnerEntity = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public record CreateStoreOwnerCommand(StoreOwnerCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<StoreOwnerKeyDto>;

internal partial class CreateStoreOwnerCommandHandler : CreateStoreOwnerCommandHandlerBase
{
	public CreateStoreOwnerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory,
		IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory)
		: base(dbContext, noxSolution,StoreFactory, entityFactory)
	{
	}
}


internal abstract class CreateStoreOwnerCommandHandlerBase : CommandBase<CreateStoreOwnerCommand,StoreOwnerEntity>, IRequestHandler <CreateStoreOwnerCommand, StoreOwnerKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory;

	public CreateStoreOwnerCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory,
		IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.StoreFactory = StoreFactory;
	}

	public virtual async Task<StoreOwnerKeyDto> Handle(CreateStoreOwnerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.StoresId.Any())
		{
			foreach(var relatedId in request.EntityDto.StoresId)
			{
				var relatedKey = ClientApi.Domain.StoreMetadata.CreateId(relatedId);
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
				var relatedEntity = StoreFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToStores(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.StoreOwners.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new StoreOwnerKeyDto(entityToCreate.Id.Value);
	}
}