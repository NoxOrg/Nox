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
using Store = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public record CreateStoreCommand(StoreCreateDto EntityDto) : IRequest<StoreKeyDto>;

public partial class CreateStoreCommandHandler: CreateStoreCommandHandlerBase
{
	public CreateStoreCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<StoreOwner,StoreOwnerCreateDto> storeownerfactory,
        IEntityFactory<Store,StoreCreateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,storeownerfactory,entityFactory, serviceProvider)
	{
	}
}


public abstract class CreateStoreCommandHandlerBase: CommandBase<CreateStoreCommand,Store>, IRequestHandler <CreateStoreCommand, StoreKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<Store,StoreCreateDto> _entityFactory;
    private readonly IEntityFactory<StoreOwner,StoreOwnerCreateDto> _storeownerfactory;

	public CreateStoreCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<StoreOwner,StoreOwnerCreateDto> storeownerfactory,
        IEntityFactory<Store,StoreCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;        
        _storeownerfactory = storeownerfactory;
	}

	public virtual async Task<StoreKeyDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.Ownership is not null)
		{ 
			var relatedEntity = _storeownerfactory.CreateEntity(request.EntityDto.Ownership);
			entityToCreate.CreateRefToStoreOwnerOwnership(relatedEntity);
		}
					
		OnCompleted(request, entityToCreate);
		_dbContext.Stores.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new StoreKeyDto(entityToCreate.Id.Value);
	}
}