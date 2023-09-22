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
using Store = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public record PartialUpdateStoreCommand(System.Guid keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <StoreKeyDto?>;

public class PartialUpdateStoreCommandHandler: PartialUpdateStoreCommandHandlerBase
{
	public PartialUpdateStoreCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Store> entityMapper): base(dbContext,noxSolution, serviceProvider, entityMapper)
	{
	}
}
public class PartialUpdateStoreCommandHandlerBase: CommandBase<PartialUpdateStoreCommand, Store>, IRequestHandler<PartialUpdateStoreCommand, StoreKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<Store> EntityMapper { get; }

	public PartialUpdateStoreCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<Store> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public virtual async Task<StoreKeyDto?> Handle(PartialUpdateStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store,Nox.Types.Guid>("Id", request.keyId);

		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<Store>(), request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new StoreKeyDto(entity.Id.Value);
	}
}