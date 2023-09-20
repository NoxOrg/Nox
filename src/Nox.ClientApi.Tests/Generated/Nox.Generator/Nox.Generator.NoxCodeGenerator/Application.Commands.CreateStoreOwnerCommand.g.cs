﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreOwner = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public record CreateStoreOwnerCommand(StoreOwnerCreateDto EntityDto) : IRequest<StoreOwnerKeyDto>;

public partial class CreateStoreOwnerCommandHandler: CreateStoreOwnerCommandHandlerBase
{
	public CreateStoreOwnerCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Store, StoreCreateDto, StoreUpdateDto> storefactory,
        IEntityFactory<StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,storefactory, entityFactory, serviceProvider)
	{
	}
}


public abstract class CreateStoreOwnerCommandHandlerBase: CommandBase<CreateStoreOwnerCommand,StoreOwner>, IRequestHandler <CreateStoreOwnerCommand, StoreOwnerKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> _entityFactory;
    private readonly IEntityFactory<Store, StoreCreateDto, StoreUpdateDto> _storefactory;

	public CreateStoreOwnerCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Store, StoreCreateDto, StoreUpdateDto> storefactory,
        IEntityFactory<StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
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