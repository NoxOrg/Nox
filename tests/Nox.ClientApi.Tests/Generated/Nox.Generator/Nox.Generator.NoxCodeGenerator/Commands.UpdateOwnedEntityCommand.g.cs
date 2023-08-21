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

public record UpdateOwnedEntityCommand(System.Int64 keyId, OwnedEntityUpdateDto EntityDto) : IRequest<OwnedEntityKeyDto?>;

public class UpdateOwnedEntityCommandHandler: CommandBase, IRequestHandler<UpdateOwnedEntityCommand, OwnedEntityKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<OwnedEntity> EntityMapper { get; }

	public UpdateOwnedEntityCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<OwnedEntity> entityMapper,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}
	
	public async Task<OwnedEntityKeyDto?> Handle(UpdateOwnedEntityCommand request, CancellationToken cancellationToken)
	{
		var keyId = CreateNoxTypeForKey<OwnedEntity,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.OwnedEntities.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<OwnedEntity>(), request.EntityDto);
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);
		
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new OwnedEntityKeyDto(entity.Id.Value);
	}
}