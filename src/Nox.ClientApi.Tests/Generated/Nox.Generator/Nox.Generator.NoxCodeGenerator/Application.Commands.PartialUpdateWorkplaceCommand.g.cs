﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Workplace = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public record PartialUpdateWorkplaceCommand(System.UInt32 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <WorkplaceKeyDto?>;

internal class PartialUpdateWorkplaceCommandHandler: PartialUpdateWorkplaceCommandHandlerBase
{
	public PartialUpdateWorkplaceCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory) : base(dbContext,noxSolution, serviceProvider, entityFactory)
	{
	}
}
internal class PartialUpdateWorkplaceCommandHandlerBase: CommandBase<PartialUpdateWorkplaceCommand, Workplace>, IRequestHandler<PartialUpdateWorkplaceCommand, WorkplaceKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> EntityFactory { get; }

	public PartialUpdateWorkplaceCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<WorkplaceKeyDto?> Handle(PartialUpdateWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Workplace,Nox.Types.Nuid>("Id", request.keyId);

		var entity = await DbContext.Workplaces.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new WorkplaceKeyDto(entity.Id.Value);
	}
}