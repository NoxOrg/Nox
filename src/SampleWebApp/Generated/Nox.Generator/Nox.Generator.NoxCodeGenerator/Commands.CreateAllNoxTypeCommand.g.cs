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

using SampleWebApp.Infrastructure.Persistence;
using SampleWebApp.Domain;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.Commands;
public record CreateAllNoxTypeCommand(AllNoxTypeCreateDto EntityDto) : IRequest<AllNoxTypeKeyDto>;

public class CreateAllNoxTypeCommandHandler: CommandBase, IRequestHandler <CreateAllNoxTypeCommand, AllNoxTypeKeyDto>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public SampleWebAppDbContext DbContext { get; }
	public IEntityFactory<AllNoxTypeCreateDto,AllNoxType> EntityFactory { get; }

	public CreateAllNoxTypeCommandHandler(
		SampleWebAppDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<AllNoxTypeCreateDto,AllNoxType> entityFactory,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<AllNoxTypeKeyDto> Handle(CreateAllNoxTypeCommand request, CancellationToken cancellationToken)
	{
		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		var createdBy = _userProvider.GetUser();
		var createdVia = _systemProvider.GetSystem();
		entityToCreate.Created(createdBy, createdVia);
	
		DbContext.AllNoxTypes.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new AllNoxTypeKeyDto(entityToCreate.Id.Value, entityToCreate.TextId.Value);
	}
}