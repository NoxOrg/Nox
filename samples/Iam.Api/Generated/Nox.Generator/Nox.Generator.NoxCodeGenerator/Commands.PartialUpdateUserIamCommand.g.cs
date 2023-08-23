﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using IamApi.Infrastructure.Persistence;
using IamApi.Domain;
using IamApi.Application.Dto;

namespace IamApi.Application.Commands;

public record PartialUpdateUserIamCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <UserIamKeyDto?>;

public class PartialUpdateUserIamCommandHandler: CommandBase<PartialUpdateUserIamCommand>, IRequestHandler<PartialUpdateUserIamCommand, UserIamKeyDto?>
{
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;

	public IamApiDbContext DbContext { get; }
	public IEntityMapper<UserIam> EntityMapper { get; }

	public PartialUpdateUserIamCommandHandler(
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

	public async Task<UserIamKeyDto?> Handle(PartialUpdateUserIamCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);
		var keyId = CreateNoxTypeForKey<UserIam,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.UserIams.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<UserIam>(), request.UpdatedProperties);
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new UserIamKeyDto(entity.Id.Value);
	}
}