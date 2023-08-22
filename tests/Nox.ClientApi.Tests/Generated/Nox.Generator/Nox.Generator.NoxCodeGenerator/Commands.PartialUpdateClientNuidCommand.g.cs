﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;

public record PartialUpdateClientNuidCommand(System.UInt32 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <ClientNuidKeyDto?>;

public class PartialUpdateClientNuidCommandHandler: CommandBase, IRequestHandler<PartialUpdateClientNuidCommand, ClientNuidKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<ClientNuid> EntityMapper { get; }

	public PartialUpdateClientNuidCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<ClientNuid> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
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

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new ClientNuidKeyDto(entity.Id.Value);
	}
}