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
public record CreateOwnedEntityCommand(OwnedEntityCreateDto EntityDto) : IRequest<OwnedEntityKeyDto>;

public class CreateOwnedEntityCommandHandler: IRequestHandler<CreateOwnedEntityCommand, OwnedEntityKeyDto>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<OwnedEntityCreateDto,OwnedEntity> EntityFactory { get; }

	public CreateOwnedEntityCommandHandler(
		ClientApiDbContext dbContext,
		IEntityFactory<OwnedEntityCreateDto,OwnedEntity> entityFactory,
		IUserProvider userProvider,
		ISystemProvider systemProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<OwnedEntityKeyDto> Handle(CreateOwnedEntityCommand request, CancellationToken cancellationToken)
	{
		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		var createdBy = _userProvider.GetUser();
		var createdVia = _systemProvider.GetSystem();
		entityToCreate.Created(createdBy, createdVia);
	
		DbContext.OwnedEntities.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new OwnedEntityKeyDto(entityToCreate.Id.Value);
	}
}