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

public record PartialUpdateStoreOwnerCommand(System.String keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <StoreOwnerKeyDto?>;

public class PartialUpdateStoreOwnerCommandHandler: CommandBase<PartialUpdateStoreOwnerCommand, StoreOwner>, IRequestHandler<PartialUpdateStoreOwnerCommand, StoreOwnerKeyDto?>
{
	public ClientApiDbContext DbContext { get; }
	public IEntityMapper<StoreOwner> EntityMapper { get; }

	public PartialUpdateStoreOwnerCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<StoreOwner> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<StoreOwnerKeyDto?> Handle(PartialUpdateStoreOwnerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<StoreOwner,Nox.Types.Text>("Id", request.keyId);

		var entity = await DbContext.StoreOwners.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<StoreOwner>(), request.UpdatedProperties);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new StoreOwnerKeyDto(entity.Id.Value);
	}
}