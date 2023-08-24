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

public record PartialUpdateUserIamCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <UserIamKeyDto?>;

public class PartialUpdateUserIamCommandHandler: CommandBase<PartialUpdateUserIamCommand, UserIam>, IRequestHandler<PartialUpdateUserIamCommand, UserIamKeyDto?>
{
	public IamApiDbContext DbContext { get; }
	public IEntityMapper<UserIam> EntityMapper { get; }

	public PartialUpdateUserIamCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<UserIam> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<UserIamKeyDto?> Handle(PartialUpdateUserIamCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<UserIam,DatabaseGuid>("Id", request.keyId);

		var entity = await DbContext.UserIams.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<UserIam>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new UserIamKeyDto(entity.Id.Value);
	}
}