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

public partial class CreateUserIamCommandHandler: CommandBase<CreateUserIamCommand>, IRequestHandler <CreateUserIamCommand, UserIamKeyDto>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public IamApiDbContext DbContext { get; }
	public IEntityFactory<UserIamCreateDto,UserIam> EntityFactory { get; }

	public CreateUserIamCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<UserIamCreateDto,UserIam> entityFactory,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<UserIamKeyDto> Handle(CreateUserIamCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		var createdBy = _userProvider.GetUser();
		var createdVia = _systemProvider.GetSystem();
		entityToCreate.Created(createdBy, createdVia);
	
		DbContext.UserIams.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new UserIamKeyDto(entityToCreate.Id.Value);
	}
}