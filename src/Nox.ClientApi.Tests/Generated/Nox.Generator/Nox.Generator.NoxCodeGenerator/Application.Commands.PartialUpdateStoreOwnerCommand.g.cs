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
using StoreOwner = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public record PartialUpdateStoreOwnerCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <StoreOwnerKeyDto?>;

internal class PartialUpdateStoreOwnerCommandHandler: PartialUpdateStoreOwnerCommandHandlerBase
{
	public PartialUpdateStoreOwnerCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory) : base(dbContext,noxSolution, entityFactory)
	{
	}
}
internal class PartialUpdateStoreOwnerCommandHandlerBase: CommandBase<PartialUpdateStoreOwnerCommand, StoreOwner>, IRequestHandler<PartialUpdateStoreOwnerCommand, StoreOwnerKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityFactory<StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> EntityFactory { get; }

	public PartialUpdateStoreOwnerCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<StoreOwner, StoreOwnerCreateDto, StoreOwnerUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<StoreOwnerKeyDto?> Handle(PartialUpdateStoreOwnerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = ClientApi.Domain.StoreOwnerMetadata.CreateId(request.keyId);

		var entity = await DbContext.StoreOwners.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new StoreOwnerKeyDto(entity.Id.Value);
	}
}