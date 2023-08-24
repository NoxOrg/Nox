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

public record UpdateWorkplaceCommand(System.Guid keyId, WorkplaceUpdateDto EntityDto) : IRequest<WorkplaceKeyDto?>;

public class UpdateWorkplaceCommandHandler: CommandBase<UpdateWorkplaceCommand, Workplace>, IRequestHandler<UpdateWorkplaceCommand, WorkplaceKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<Workplace> EntityMapper { get; }

	public UpdateWorkplaceCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Workplace> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<WorkplaceKeyDto?> Handle(UpdateWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Workplace,DatabaseGuid>("Id", request.keyId);
	
		var entity = await DbContext.Workplaces.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<Workplace>(), request.EntityDto);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new WorkplaceKeyDto(entity.Id.Value);
	}
}