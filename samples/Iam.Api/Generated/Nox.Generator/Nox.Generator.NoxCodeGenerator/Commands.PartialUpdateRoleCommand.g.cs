﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using IamApi.Infrastructure.Persistence;
using IamApi.Domain;
using IamApi.Application.Dto;

namespace IamApi.Application.Commands;

public record PartialUpdateRoleCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <RoleKeyDto?>;

public class PartialUpdateRoleCommandHandler: CommandBase<PartialUpdateRoleCommand, Role>, IRequestHandler<PartialUpdateRoleCommand, RoleKeyDto?>
{
	public IamApiDbContext DbContext { get; }
	public IEntityMapper<Role> EntityMapper { get; }

	public PartialUpdateRoleCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Role> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<RoleKeyDto?> Handle(PartialUpdateRoleCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Role,Text>("Id", request.keyId);

		var entity = await DbContext.Roles.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Role>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new RoleKeyDto(entity.Id.Value);
	}
}