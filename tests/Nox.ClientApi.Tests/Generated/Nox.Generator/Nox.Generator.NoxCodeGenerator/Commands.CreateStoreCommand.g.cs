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

namespace ClientApi.Application.Commands;
public record CreateStoreCommand(StoreCreateDto EntityDto) : IRequest<StoreKeyDto>;

public partial class CreateStoreCommandHandler: CommandBase<CreateStoreCommand,Store>, IRequestHandler <CreateStoreCommand, StoreKeyDto>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<StoreCreateDto,Store> EntityFactory { get; }

	public CreateStoreCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<StoreCreateDto,Store> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<StoreKeyDto> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		entityToCreate.EnsureId();
	
		DbContext.Stores.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new StoreKeyDto(entityToCreate.Id.Value);
	}
}