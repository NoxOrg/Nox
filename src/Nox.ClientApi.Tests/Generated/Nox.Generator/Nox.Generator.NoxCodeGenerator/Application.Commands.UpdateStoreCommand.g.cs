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
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public record UpdateStoreCommand(System.Guid keyId, StoreUpdateDto EntityDto, System.Guid? Etag) : IRequest<StoreKeyDto?>;

internal partial class UpdateStoreCommandHandler : UpdateStoreCommandHandlerBase
{
	public UpdateStoreCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory): base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateStoreCommandHandlerBase : CommandBase<UpdateStoreCommand, StoreEntity>, IRequestHandler<UpdateStoreCommand, StoreKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	private readonly IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> _entityFactory;

	public UpdateStoreCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory): base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<StoreKeyDto?> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = ClientApi.Domain.StoreMetadata.CreateId(request.keyId);

		var entity = await DbContext.Stores.FindAsync(keyId);
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

		return new StoreKeyDto(entity.Id.Value);
	}
}