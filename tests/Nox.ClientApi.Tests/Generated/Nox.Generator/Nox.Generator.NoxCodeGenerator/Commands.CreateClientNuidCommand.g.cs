﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;
public record CreateClientNuidCommand(ClientNuidCreateDto EntityDto) : IRequest<ClientNuidKeyDto>;

public class CreateClientNuidCommandHandler: IRequestHandler<CreateClientNuidCommand, ClientNuidKeyDto>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<ClientNuidCreateDto,ClientNuid> EntityFactory { get; }

	public CreateClientNuidCommandHandler(
		ClientApiDbContext dbContext,
		IEntityFactory<ClientNuidCreateDto,ClientNuid> entityFactory,
		IUserProvider userProvider,
		ISystemProvider systemProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<ClientNuidKeyDto> Handle(CreateClientNuidCommand request, CancellationToken cancellationToken)
	{
		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		entityToCreate.EnsureId();
		var createdBy = _userProvider.GetUser();
		var createdVia = _systemProvider.GetSystem();
		entityToCreate.Created(createdBy, createdVia);
	
		DbContext.ClientNuids.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ClientNuidKeyDto(entityToCreate.Id.Value);
	}
}