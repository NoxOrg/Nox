﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
public record CreateClientDatabaseGuidCommand(ClientDatabaseGuidCreateDto EntityDto) : IRequest<ClientDatabaseGuidKeyDto>;

public partial class CreateClientDatabaseGuidCommandHandler: CommandBase<CreateClientDatabaseGuidCommand>, IRequestHandler <CreateClientDatabaseGuidCommand, ClientDatabaseGuidKeyDto>
{
	public SampleWebAppDbContext DbContext { get; }
	public IEntityFactory<ClientDatabaseGuidCreateDto,ClientDatabaseGuid> EntityFactory { get; }

	public CreateClientDatabaseGuidCommandHandler(
		SampleWebAppDbContext dbContext,
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