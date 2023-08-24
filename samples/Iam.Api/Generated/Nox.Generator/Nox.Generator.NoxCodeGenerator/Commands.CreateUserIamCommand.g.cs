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
public record CreateUserIamCommand(UserIamCreateDto EntityDto) : IRequest<UserIamKeyDto>;

public partial class CreateUserIamCommandHandler: CommandBase<CreateUserIamCommand,UserIam>, IRequestHandler <CreateUserIamCommand, UserIamKeyDto>
{
	public IamApiDbContext DbContext { get; }
	public IEntityFactory<UserIamCreateDto,UserIam> EntityFactory { get; }

	public CreateUserIamCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<UserIamCreateDto,UserIam> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<UserIamKeyDto> Handle(CreateUserIamCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
	
		OnCompleted(entityToCreate);
		DbContext.UserIams.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new UserIamKeyDto(entityToCreate.Id.Value);
	}
}