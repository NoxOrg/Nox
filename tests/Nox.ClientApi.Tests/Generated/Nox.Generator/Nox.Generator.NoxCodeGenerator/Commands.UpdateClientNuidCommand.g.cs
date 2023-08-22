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

public record UpdateClientNuidCommand(System.UInt32 keyId, ClientNuidUpdateDto EntityDto) : IRequest<ClientNuidKeyDto?>;

public class UpdateClientNuidCommandHandler: CommandBase, IRequestHandler<UpdateClientNuidCommand, ClientNuidKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<ClientNuid> EntityMapper { get; }

	public UpdateClientNuidCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<ClientNuid> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
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

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new ClientNuidKeyDto(entity.Id.Value);
	}
}