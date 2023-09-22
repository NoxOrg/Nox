﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreDescription = ClientApi.Domain.StoreDescription;

namespace ClientApi.Application.Commands;

public record CreateStoreDescriptionCommand(StoreDescriptionCreateDto EntityDto) : IRequest<StoreDescriptionKeyDto>;

public partial class CreateStoreDescriptionCommandHandler: CreateStoreDescriptionCommandHandlerBase
{
	public CreateStoreDescriptionCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<StoreDescription, StoreDescriptionCreateDto, StoreDescriptionUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,entityFactory, serviceProvider)
	{
	}
}


public abstract class CreateStoreDescriptionCommandHandlerBase: CommandBase<CreateStoreDescriptionCommand,StoreDescription>, IRequestHandler <CreateStoreDescriptionCommand, StoreDescriptionKeyDto>
{
	private readonly ClientApiDbContext _dbContext;
	private readonly IEntityFactory<StoreDescription, StoreDescriptionCreateDto, StoreDescriptionUpdateDto> _entityFactory;

	public CreateStoreDescriptionCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<StoreDescription, StoreDescriptionCreateDto, StoreDescriptionUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<StoreDescriptionKeyDto> Handle(CreateStoreDescriptionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);

		OnCompleted(request, entityToCreate);
		_dbContext.StoreDescriptions.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new StoreDescriptionKeyDto(entityToCreate.StoreId.Value, entityToCreate.Id.Value);
	}
}