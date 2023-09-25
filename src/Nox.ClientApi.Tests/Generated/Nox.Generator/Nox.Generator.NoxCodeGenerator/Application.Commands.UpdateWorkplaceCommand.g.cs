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
using Workplace = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public record UpdateWorkplaceCommand(System.UInt32 keyId, WorkplaceUpdateDto EntityDto, System.Guid? Etag) : IRequest<WorkplaceKeyDto?>;

internal partial class UpdateWorkplaceCommandHandler: UpdateWorkplaceCommandHandlerBase
{
	public UpdateWorkplaceCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory): base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}

internal abstract class UpdateWorkplaceCommandHandlerBase: CommandBase<UpdateWorkplaceCommand, Workplace>, IRequestHandler<UpdateWorkplaceCommand, WorkplaceKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	private readonly IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> _entityFactory;

	public UpdateWorkplaceCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<Workplace, WorkplaceCreateDto, WorkplaceUpdateDto> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<WorkplaceKeyDto?> Handle(UpdateWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Workplace,Nox.Types.Nuid>("Id", request.keyId);

		var entity = await DbContext.Workplaces.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new WorkplaceKeyDto(entity.Id.Value);
	}
}