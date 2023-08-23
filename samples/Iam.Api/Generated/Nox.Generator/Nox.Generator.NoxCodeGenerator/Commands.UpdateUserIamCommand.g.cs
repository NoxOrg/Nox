﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using IamApi.Infrastructure.Persistence;
using IamApi.Domain;
using IamApi.Application.Dto;

namespace IamApi.Application.Commands;

public record UpdateUserIamCommand(System.Int64 keyId, UserIamUpdateDto EntityDto) : IRequest<UserIamKeyDto?>;

public class UpdateUserIamCommandHandler: CommandBase<UpdateUserIamCommand>, IRequestHandler<UpdateUserIamCommand, UserIamKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public IamApiDbContext DbContext { get; }
	public IEntityMapper<UserIam> EntityMapper { get; }

	public UpdateUserIamCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<UserIam> entityMapper,
		IUserProvider userProvider,
		ISystemProvider systemProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
		_userProvider = userProvider;
		_systemProvider = systemProvider;
	}
	
	public async Task<UserIamKeyDto?> Handle(UpdateUserIamCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<UserIam,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.UserIams.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<UserIam>(), request.EntityDto);
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);
		
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new UserIamKeyDto(entity.Id.Value);
	}
}