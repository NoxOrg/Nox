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

using IamApi.Infrastructure.Persistence;
using IamApi.Domain;
using IamApi.Application.Dto;

namespace IamApi.Application.Commands;
public record CreateRoleCommand(RoleCreateDto EntityDto) : IRequest<RoleKeyDto>;

public partial class CreateRoleCommandHandler: CommandBase<CreateRoleCommand,Role>, IRequestHandler <CreateRoleCommand, RoleKeyDto>
{
	public IamApiDbContext DbContext { get; }
	public IEntityFactory<RoleCreateDto,Role> EntityFactory { get; }

	public CreateRoleCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<RoleCreateDto,Role> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<RoleKeyDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.Roles.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new RoleKeyDto(entityToCreate.Id.Value);
	}
}