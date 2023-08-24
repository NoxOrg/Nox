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
public record CreateWorkplaceCommand(WorkplaceCreateDto EntityDto) : IRequest<WorkplaceKeyDto>;

public partial class CreateWorkplaceCommandHandler: CommandBase<CreateWorkplaceCommand,Workplace>, IRequestHandler <CreateWorkplaceCommand, WorkplaceKeyDto>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<WorkplaceCreateDto,Workplace> EntityFactory { get; }

	public CreateWorkplaceCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<WorkplaceCreateDto,Workplace> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<WorkplaceKeyDto> Handle(CreateWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.Workplaces.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new WorkplaceKeyDto(entityToCreate.Id.Value);
	}
}