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

public partial class CreateStoreOwnerCommandHandler: CommandBase<CreateStoreOwnerCommand,StoreOwner>, IRequestHandler <CreateStoreOwnerCommand, StoreOwnerKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<StoreOwnerCreateDto,StoreOwner> _entityFactory;

	public CreateStoreOwnerCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<StoreOwnerCreateDto,StoreOwner> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public async Task<StoreOwnerKeyDto> Handle(CreateStoreOwnerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);		
	
		OnCompleted(entityToCreate);
		_dbContext.StoreOwners.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new StoreOwnerKeyDto(entityToCreate.Id.Value);
	}
}