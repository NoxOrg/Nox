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

public record UpdateApplicationIAMCommand(System.Int64 keyId, ApplicationIAMUpdateDto EntityDto) : IRequest<ApplicationIAMKeyDto?>;

public class UpdateApplicationIAMCommandHandler: CommandBase<UpdateApplicationIAMCommand, ApplicationIAM>, IRequestHandler<UpdateApplicationIAMCommand, ApplicationIAMKeyDto?>
{
	public IamApiDbContext DbContext { get; }
	public IEntityMapper<ApplicationIAM> EntityMapper { get; }

	public UpdateApplicationIAMCommandHandler(
		IamApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<ApplicationIAM> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<ApplicationIAMKeyDto?> Handle(UpdateApplicationIAMCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<ApplicationIAM,DatabaseNumber>("Id", request.keyId);
	
		var entity = await DbContext.ApplicationIAMs.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<ApplicationIAM>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new ApplicationIAMKeyDto(entity.Id.Value);
	}
}