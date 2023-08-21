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

public record PartialUpdateClientNuidCommand(System.UInt32 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <ClientNuidKeyDto?>;

public class PartialUpdateClientNuidCommandHandler: CommandBase, IRequestHandler<PartialUpdateClientNuidCommand, ClientNuidKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<ClientNuid> EntityMapper { get; }

	public PartialUpdateClientNuidCommandHandler(
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

	public async Task<ClientNuidKeyDto?> Handle(PartialUpdateClientNuidCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<ClientNuid,Nuid>("Id", request.keyId);

		var entity = await DbContext.ClientNuids.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<ClientNuid>(), request.UpdatedProperties);
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new ClientNuidKeyDto(entity.Id.Value);
	}
}