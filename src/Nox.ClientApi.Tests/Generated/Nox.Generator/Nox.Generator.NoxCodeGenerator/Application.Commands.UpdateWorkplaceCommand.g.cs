﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public record UpdateWorkplaceCommand(System.UInt32 keyId, WorkplaceUpdateDto EntityDto, System.Guid? Etag) : IRequest<WorkplaceKeyDto?>;

internal partial class UpdateWorkplaceCommandHandler : UpdateWorkplaceCommandHandlerBase
{
	public UpdateWorkplaceCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateWorkplaceCommandHandlerBase : CommandBase<UpdateWorkplaceCommand, WorkplaceEntity>, IRequestHandler<UpdateWorkplaceCommand, WorkplaceKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	private readonly IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> _entityFactory;

	public UpdateWorkplaceCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<WorkplaceKeyDto?> Handle(UpdateWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = ClientApi.Domain.WorkplaceMetadata.CreateId(request.keyId);

		var entity = await DbContext.Workplaces.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new WorkplaceKeyDto(entity.Id.Value);
	}
}