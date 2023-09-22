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
using StoreDescription = ClientApi.Domain.StoreDescription;

namespace ClientApi.Application.Commands;

public record PartialUpdateStoreDescriptionCommand(System.Guid keyStoreId, System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <StoreDescriptionKeyDto?>;

public class PartialUpdateStoreDescriptionCommandHandler: PartialUpdateStoreDescriptionCommandHandlerBase
{
	public PartialUpdateStoreDescriptionCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<StoreDescription> entityMapper): base(dbContext,noxSolution, serviceProvider, entityMapper)
	{
	}
}
public class PartialUpdateStoreDescriptionCommandHandlerBase: CommandBase<PartialUpdateStoreDescriptionCommand, StoreDescription>, IRequestHandler<PartialUpdateStoreDescriptionCommand, StoreDescriptionKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<StoreDescription> EntityMapper { get; }

	public PartialUpdateStoreDescriptionCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<StoreDescription> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public virtual async Task<StoreDescriptionKeyDto?> Handle(PartialUpdateStoreDescriptionCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyStoreId = CreateNoxTypeForKey<StoreDescription,Nox.Types.Guid>("StoreId", request.keyStoreId);
		var keyId = CreateNoxTypeForKey<StoreDescription,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.StoreDescriptions.FindAsync(keyStoreId, keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<StoreDescription>(), request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new StoreDescriptionKeyDto(entity.StoreId.Value, entity.Id.Value);
	}
}