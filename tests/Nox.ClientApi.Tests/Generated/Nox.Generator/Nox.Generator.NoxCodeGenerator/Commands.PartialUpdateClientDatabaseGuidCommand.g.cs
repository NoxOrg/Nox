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

public record PartialUpdateClientDatabaseGuidCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <ClientDatabaseGuidKeyDto?>;

public class PartialUpdateClientDatabaseGuidCommandHandler: CommandBase<PartialUpdateClientDatabaseGuidCommand>, IRequestHandler<PartialUpdateClientDatabaseGuidCommand, ClientDatabaseGuidKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<ClientDatabaseGuid> EntityMapper { get; }

	public PartialUpdateClientDatabaseGuidCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<ClientDatabaseGuid> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<ClientDatabaseGuidKeyDto?> Handle(PartialUpdateClientDatabaseGuidCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<ClientDatabaseGuid,DatabaseGuid>("Id", request.keyId);

		var entity = await DbContext.ClientDatabaseGuids.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<ClientDatabaseGuid>(), request.UpdatedProperties);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new ClientDatabaseGuidKeyDto(entity.Id.Value);
	}
}