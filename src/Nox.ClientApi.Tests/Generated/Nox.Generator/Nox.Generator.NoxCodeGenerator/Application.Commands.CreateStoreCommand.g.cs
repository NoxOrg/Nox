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

public partial class CreateStoreCommandHandler: CommandBase<CreateStoreCommand,Store>, IRequestHandler <CreateStoreCommand, StoreKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<StoreCreateDto,Store> _entityFactory;

	public CreateStoreCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<StoreCreateDto,Store> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public async Task<StoreKeyDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		entityToCreate.EnsureId();		
	
		OnCompleted(entityToCreate);
		_dbContext.Stores.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new StoreKeyDto(entityToCreate.Id.Value);
	}
}