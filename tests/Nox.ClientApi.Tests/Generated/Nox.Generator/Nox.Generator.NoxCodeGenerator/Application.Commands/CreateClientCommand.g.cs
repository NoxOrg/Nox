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
using ClientEntity = ClientApi.Domain.Client;

namespace ClientApi.Application.Commands;

public partial record CreateClientCommand(ClientCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<ClientKeyDto>;

internal partial class CreateClientCommandHandler : CreateClientCommandHandlerBase
{
	public CreateClientCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory,
		IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> entityFactory)
		: base(dbContext, noxSolution,StoreFactory, entityFactory)
	{
	}
}


internal abstract class CreateClientCommandHandlerBase : CommandBase<CreateClientCommand,ClientEntity>, IRequestHandler <CreateClientCommand, ClientKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> EntityFactory;
	protected readonly IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory;

	protected CreateClientCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> StoreFactory,
		IEntityFactory<ClientEntity, ClientCreateDto, ClientUpdateDto> entityFactory)
	: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.StoreFactory = StoreFactory;
	}

	public virtual async Task<ClientKeyDto> Handle(CreateClientCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
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
		DbContext.Clients.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ClientKeyDto(entityToCreate.Id.Value);
	}
}