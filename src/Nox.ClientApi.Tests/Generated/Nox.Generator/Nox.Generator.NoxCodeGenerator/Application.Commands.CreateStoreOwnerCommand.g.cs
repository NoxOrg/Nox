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
using StoreOwnerEntity = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public record CreateStoreOwnerCommand(StoreOwnerCreateDto EntityDto) : IRequest<StoreOwnerKeyDto>;

internal partial class CreateStoreOwnerCommandHandler : CreateStoreOwnerCommandHandlerBase
{
	public CreateStoreOwnerCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> storefactory,
		IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory)
		: base(dbContext, noxSolution,storefactory, entityFactory)
	{
	}
}


internal abstract class CreateStoreOwnerCommandHandlerBase : CommandBase<CreateStoreOwnerCommand,StoreOwnerEntity>, IRequestHandler <CreateStoreOwnerCommand, StoreOwnerKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> _entityFactory;
	private readonly IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> _storefactory;

	public CreateStoreOwnerCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ClientApi.Domain.Store, StoreCreateDto, StoreUpdateDto> storefactory,
		IEntityFactory<StoreOwnerEntity, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_storefactory = storefactory;
	}

	public virtual async Task<StoreOwnerKeyDto> Handle(CreateStoreOwnerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.Stores)
		{
			var relatedEntity = _storefactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToStores(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.StoreOwners.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new StoreOwnerKeyDto(entityToCreate.Id.Value);
	}
}