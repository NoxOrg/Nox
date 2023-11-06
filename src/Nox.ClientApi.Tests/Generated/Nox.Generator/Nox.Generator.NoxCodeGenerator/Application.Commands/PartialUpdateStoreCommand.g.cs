﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public partial record PartialUpdateStoreCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <StoreKeyDto?>;

internal class PartialUpdateStoreCommandHandler : PartialUpdateStoreCommandHandlerBase
{
	public PartialUpdateStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateStoreCommandHandlerBase : CommandBase<PartialUpdateStoreCommand, StoreEntity>, IRequestHandler<PartialUpdateStoreCommand, StoreKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> EntityFactory { get; }

	public PartialUpdateStoreCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreEntity, StoreCreateDto, StoreUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<StoreKeyDto?> Handle(PartialUpdateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.StoreMetadata.CreateId(request.keyId);

		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new StoreKeyDto(entity.Id.Value);
	}
}