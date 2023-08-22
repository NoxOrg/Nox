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

public record PartialUpdateOwnedEntityCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <OwnedEntityKeyDto?>;

public class PartialUpdateOwnedEntityCommandHandler: CommandBase, IRequestHandler<PartialUpdateOwnedEntityCommand, OwnedEntityKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<OwnedEntity> EntityMapper { get; }

	public PartialUpdateOwnedEntityCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<OwnedEntity> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<OwnedEntityKeyDto?> Handle(PartialUpdateOwnedEntityCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<OwnedEntity,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.OwnedEntities.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<OwnedEntity>(), request.UpdatedProperties);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new OwnedEntityKeyDto(entity.Id.Value);
	}
}