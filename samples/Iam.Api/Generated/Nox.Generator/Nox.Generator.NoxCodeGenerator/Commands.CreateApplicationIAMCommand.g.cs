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
public record CreateApplicationIAMCommand(ApplicationIAMCreateDto EntityDto) : IRequest<ApplicationIAMKeyDto>;

public partial class CreateApplicationIAMCommandHandler: CommandBase<CreateApplicationIAMCommand>, IRequestHandler <CreateApplicationIAMCommand, ApplicationIAMKeyDto>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public IamApiDbContext DbContext { get; }
	public IEntityFactory<ApplicationIAMCreateDto,ApplicationIAM> EntityFactory { get; }

	public CreateApplicationIAMCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<ApplicationIAMCreateDto,ApplicationIAM> entityFactory,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<ApplicationIAMKeyDto> Handle(CreateApplicationIAMCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		var createdBy = _userProvider.GetUser();
		var createdVia = _systemProvider.GetSystem();
		entityToCreate.Created(createdBy, createdVia);
	
		DbContext.ApplicationIAMs.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new ApplicationIAMKeyDto(entityToCreate.Id.Value);
	}
}