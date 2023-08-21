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

public record PartialUpdateClientDatabaseNumberCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <ClientDatabaseNumberKeyDto?>;

public class PartialUpdateClientDatabaseNumberCommandHandler: CommandBase, IRequestHandler<PartialUpdateClientDatabaseNumberCommand, ClientDatabaseNumberKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<ClientDatabaseNumber> EntityMapper { get; }

	public PartialUpdateClientDatabaseNumberCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<ClientDatabaseNumber> entityMapper,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}

	public async Task<ClientDatabaseNumberKeyDto?> Handle(PartialUpdateClientDatabaseNumberCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<ClientDatabaseNumber,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.ClientDatabaseNumbers.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<ClientDatabaseNumber>(), request.UpdatedProperties);
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new ClientDatabaseNumberKeyDto(entity.Id.Value);
	}
}