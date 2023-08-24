﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using IamApi.Infrastructure.Persistence;
using IamApi.Domain;
using IamApi.Application.Dto;

namespace IamApi.Application.Commands;

public record UpdateRoleCommand(System.String keyId, RoleUpdateDto EntityDto) : IRequest<RoleKeyDto?>;

public class UpdateRoleCommandHandler: CommandBase<UpdateRoleCommand, Role>, IRequestHandler<UpdateRoleCommand, RoleKeyDto?>
{
	public IamApiDbContext DbContext { get; }
	public IEntityMapper<Role> EntityMapper { get; }

	public UpdateRoleCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Role> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<RoleKeyDto?> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Role,Text>("Id", request.keyId);
	
		var entity = await DbContext.Roles.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<Role>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new RoleKeyDto(entity.Id.Value);
	}
}