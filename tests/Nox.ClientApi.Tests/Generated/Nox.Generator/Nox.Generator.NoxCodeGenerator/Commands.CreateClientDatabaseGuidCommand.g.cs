﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;
public record CreateClientDatabaseGuidCommand(ClientDatabaseGuidCreateDto EntityDto) : IRequest<ClientDatabaseGuidKeyDto>;

public class CreateClientDatabaseGuidCommandHandler: IRequestHandler<CreateClientDatabaseGuidCommand, ClientDatabaseGuidKeyDto>
{

	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<ClientDatabaseGuidCreateDto,ClientDatabaseGuid> EntityFactory { get; }

	public CreateClientDatabaseGuidCommandHandler(
		ClientApiDbContext dbContext,
		IEntityFactory<ClientDatabaseGuidCreateDto,ClientDatabaseGuid> entityFactory)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<ClientDatabaseGuidKeyDto> Handle(CreateClientDatabaseGuidCommand request, CancellationToken cancellationToken)
	{
		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.ClientDatabaseGuids.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ClientDatabaseGuidKeyDto(entityToCreate.Id.Value);
	}
}