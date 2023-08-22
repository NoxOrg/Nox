﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.Commands;

public record UpdateClientDatabaseGuidCommand(System.Int64 keyId, ClientDatabaseGuidUpdateDto EntityDto) : IRequest<ClientDatabaseGuidKeyDto?>;

public class UpdateClientDatabaseGuidCommandHandler: CommandBase, IRequestHandler<UpdateClientDatabaseGuidCommand, ClientDatabaseGuidKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<ClientDatabaseGuid> EntityMapper { get; }

	public UpdateClientDatabaseGuidCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<ClientDatabaseGuid> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<ClientDatabaseGuidKeyDto?> Handle(UpdateClientDatabaseGuidCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<ClientDatabaseGuid,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.ClientDatabaseGuids.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<ClientDatabaseGuid>(), request.EntityDto);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new ClientDatabaseGuidKeyDto(entity.Id.Value);
	}
}