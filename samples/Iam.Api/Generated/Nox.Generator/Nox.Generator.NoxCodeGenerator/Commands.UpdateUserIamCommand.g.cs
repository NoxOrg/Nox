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

public record UpdateUserIamCommand(System.Guid keyId, UserIamUpdateDto EntityDto) : IRequest<UserIamKeyDto?>;

public class UpdateUserIamCommandHandler: CommandBase<UpdateUserIamCommand, UserIam>, IRequestHandler<UpdateUserIamCommand, UserIamKeyDto?>
{
	public IamApiDbContext DbContext { get; }
	public IEntityMapper<UserIam> EntityMapper { get; }

	public UpdateUserIamCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<UserIam> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<UserIamKeyDto?> Handle(UpdateUserIamCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<UserIam,DatabaseGuid>("Id", request.keyId);
	
		var entity = await DbContext.UserIams.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<UserIam>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new UserIamKeyDto(entity.Id.Value);
	}
}