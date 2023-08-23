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

namespace ClientApi.Application.Commands;
public record CreateClientDatabaseGuidCommand(ClientDatabaseGuidCreateDto EntityDto) : IRequest<ClientDatabaseGuidKeyDto>;

public partial class CreateClientDatabaseGuidCommandHandler: CommandBase<CreateClientDatabaseGuidCommand>, IRequestHandler <CreateClientDatabaseGuidCommand, ClientDatabaseGuidKeyDto>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<ClientDatabaseGuidCreateDto,ClientDatabaseGuid> EntityFactory { get; }

	public CreateClientDatabaseGuidCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<ClientDatabaseGuidCreateDto,ClientDatabaseGuid> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<ClientDatabaseGuidKeyDto> Handle(CreateClientDatabaseGuidCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		DbContext.ClientDatabaseGuids.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ClientDatabaseGuidKeyDto(entityToCreate.Id.Value);
	}
}