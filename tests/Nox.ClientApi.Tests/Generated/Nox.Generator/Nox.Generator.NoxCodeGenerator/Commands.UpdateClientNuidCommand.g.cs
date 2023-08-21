﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;

public record UpdateClientNuidCommand(System.UInt32 keyId, ClientNuidUpdateDto EntityDto) : IRequest<ClientNuidKeyDto?>;

public class UpdateClientNuidCommandHandler: CommandBase, IRequestHandler<UpdateClientNuidCommand, ClientNuidKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<ClientNuid> EntityMapper { get; }

	public UpdateClientNuidCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<ClientNuid> entityMapper,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}
	
	public async Task<ClientNuidKeyDto?> Handle(UpdateClientNuidCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<ClientNuid,Nuid>("Id", request.keyId);
	
		var entity = await DbContext.ClientNuids.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<ClientNuid>(), request.EntityDto);
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);
		
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new ClientNuidKeyDto(entity.Id.Value);
	}
}