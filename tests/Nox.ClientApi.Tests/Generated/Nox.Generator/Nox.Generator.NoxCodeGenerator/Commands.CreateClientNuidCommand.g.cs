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
public record CreateClientNuidCommand(ClientNuidCreateDto EntityDto) : IRequest<ClientNuidKeyDto>;

public class CreateClientNuidCommandHandler: CommandBase, IRequestHandler <CreateClientNuidCommand, ClientNuidKeyDto>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<ClientNuidCreateDto,ClientNuid> EntityFactory { get; }

	public CreateClientNuidCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<ClientNuidCreateDto,ClientNuid> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<ClientNuidKeyDto> Handle(CreateClientNuidCommand request, CancellationToken cancellationToken)
	{
		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		entityToCreate.EnsureId();
	
		DbContext.ClientNuids.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ClientNuidKeyDto(entityToCreate.Id.Value);
	}
}